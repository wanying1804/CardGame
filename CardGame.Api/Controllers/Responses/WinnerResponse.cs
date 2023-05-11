using CardGame.Domain.Enums;

namespace CardGame.API.Controllers.Responses;

public record WinnerResponse(PlayerType? PlayerType);