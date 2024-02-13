using Microsoft.VisualStudio.TestPlatform.TestHost;
using Specification.Controllers;
using Specification.Infrastructure.Persistence;
using Xunit;

namespace Specification.Tests;

public class CircleControllerTests : IClassFixture<PostgresFactory<Program, ApplicationDbContext>>
{
    public CircleControllerTests()
    {
        
    }

    [Fact]
    public async Task Should_Be_Circle_Count_Is_Five()
    {
        
    }
}
