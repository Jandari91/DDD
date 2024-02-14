# Specification

## 명세란?
명세란 도메인이 가져야 하는 여러 조건들을 평가하기 위해 사용하는 방법이다.

## 왜 사용해야 하는가?

대부분 도메인 모델에 평가하는 코드를 넣지만 너무 복잡해지면 나도 모르게 Application Service에 넣는 경향이 많다.

예를 들어 아래와 같은 조건이 있다.

* 사용자 중에 프리미엄 사용자라는 유형이 존재한다.
* 서클의 최대 인원은 서클장과 소속 사용자를 포함해 3명이다.
* 프리미엄 사용자가 1명 이상 소속된 서클은 최대 인원이 5명으로 늘어난다.

```cs
public class CircleApplicationService : ICircleApplicationService
{
    private readonly ICircleRepository circleRepository;
    private readonly IUserRepository userRepository;
    (....생략....)

    public async Task Join(CircleJoinCommand command)
    {
        var circleId = command.CircleId;
        var circle = await circleRepository.GetAsync(circleId);
        var members = circle.Users;
        var premiumUserNumber = members.Count(user => user.IsPremium);
        var circleUpperLimit = premiumUserNumber < 1 ? 3 : 5;
        if(circle.CountMembers() >= circleUpperLimit)
        {
            throw new CircleFullException(circleId);
        }
        var newMember = await userRepository.GetAsync(command.UserId);
        circle.Users.Add(newMember);
        await circleRepository.UpdateAsync(circle);
    }
}
```
대부분 사람들은 위와 같이 Application Service에 직접 넣던가 아니면 서브 클래스를 생성해서 넣는다.  
하지만 도메인 로직은 Domain Model이나 Domain Service에 넣어야지 Application Service에는 넣으면 안된다.  
Application Service에 도메인 로직이 들어가게 되면 비슷한 기능을 하는 서비스들에 도메인 로직이 흩어지게 된다.  

하지만 도메인을 평가하는 로직은 도메인 로직의 주가 아니기 때문에 Domain Model이나 Domain Service에 넣기에는 부담스러운 경우가 있다.

이때 사용하는게 명세이다.

```cs
public class CircleApplicationService : ICircleApplicationService
{
    private readonly ICircleRepository circleRepository;
    private readonly IUserRepository userRepository;
    // (....생략....)

    public async Task Join(CircleJoinCommand command)
    {
        var circleId = command.CircleId;
        var circle = await circleRepository.GetAsync(circleId);

        var fullSpec = new CircleFullSpecification();
        if (fullSpec.IsSatisfiedBy(circle))
        {
            throw new CircleFullException(circleId);
        }

        var newMember = await userRepository.GetAsync(command.UserId);
        circle.Users.Add(newMember);
        await circleRepository.UpdateAsync(circle);
    }
}
```


## 레파지토리 vs 명세

Circle 중 최근(2달)에 만들어진 Circle을 추천 받는 도메인이 있다고 하자.  
그럼 Repository에서 아래와 같이 생성하게 되는데, 이는 도메인이 늘어나면 늘어날 수록 Repository의 메서드가 굉장히 늘어나게 된다.

```cs
public class CircleRepository : ICircleRepository
{
    // (...생략...)
    public async Task<IEnumerable<Circle>> GetRecommendCircle()
    {

        var now = DateTime.UtcNow;
        var circles = await Task.Run(() => _dbContext.Circles.Where(c => c.Created > now.AddMonths(-2)).Take(10).ToList());
        return circles;
    }
}
```


이러한 도메인을 명세를 사용하면 간단하게 해결 할 수 있다.

```cs
public class CircleSpecApplicationService : ICircleApplicationService
{

    public async Task<IEnumerable<Circle>> GetRecommend()
    { 
        var now = DateTime.UtcNow;
        var spec = new CircleRecommendSpecification(now);


        var circles = await circleRepository.GetAllAsync();
        var recommendCircles = circles
            .Where(spec.IsSatisfiedBy)
            .Take(10)
            .ToList();
        return recommendCircles;
    }

}
```


#### 단점

위와 같이 `GetAllAsync()`를 통해 전부 조회 한 후 명세를 통해 필터링 하는 방법은 성능상 문제가 있다.  
그래서 Repository에서 `GetAllAsync(ISpecification<Circle> spec)`을 받아 쿼리를 수정해 줘야 한다.


## Specification vs. CQRS

참고

* https://enterprisecraftsmanship.com/posts/cqrs-vs-specification-pattern/
* https://groups.google.com/g/dddcqrs/c/wYZ4zry5r9E


위 마지막 Repository에서 Specification을 사용하여 쿼리하는 방법이 단점이라고 하였다.  
그 이유는 쿼리는 굉장히 많은 도메인을 가지고 있기 때문에 `GetAllAsync(ISpecification<Circle> spec)`와 같은 방법으로는 전부 표현이 불가능하다.  
그래서 나온 아이디어가 CQRS이다.


* CQRS는 읽기와 쓰기를 분리한 모델입니다.  
* CQRS의 가장 중요한 원칙은 느슨한 결합으로 중복 코드가 어느 정도 발생 할 수 있습니다.  
* 명세는 DRY(Don't Repeat Yourself)로 중복코드가 발생하지 않는 것을 가장 중요하게 생각합니다.  

대부분 가장 간단한 로직인 아니고선 느슨한 결합이 DRY 보다 더 활용도가 높고 이점이 많습니다.

```cs
public class GetRecommendCircleQueryHandler : IRequestHandler<GetRecommendCircleQuery, IEnumerable<CircleDto>>
{
  private readonly ApplicationDbContext _dbContext;
  private readonly IMapper _mapper;
  public GetRecommendCircleQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }

  public async Task<IEnumerable<CircleDto>> Handle(GetRecommendCircleQuery request, CancellationToken cancellationToken)
  {
    var now = DateTime.UtcNow;
    var circles = await _dbContext.Circles.Include(e => e.Users).Where(e => e.Created > now.AddMonths(-2)).Take(10).OrderBy(_ => _.Id).ToListAsync();
    return _mapper.Map<IEnumerable<CircleDto>>(circles);
  }
}
```


## 참고


* CQRS를 사용하면 Specification과 Repository를 사용 할 필요가 없습니다.
* https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design#repositories-shouldnt-be-mandatory