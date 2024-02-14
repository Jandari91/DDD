namespace Domain.Exception;

public class CircleFullException : System.Exception
{
    public CircleFullException(long circleId)
        :base($"This Circle Is Full : {circleId}")
    {

    }
}
