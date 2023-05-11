namespace CardGame.API.Controllers.Responses;

public class SuccessMessage
{
    public string Message { get; init; }

    public SuccessMessage(string message)
    {
        Message = message;
    }
}