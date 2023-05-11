using System.Text.Json.Serialization;
using CardGame.Domain.Entities;
using CardGame.Domain.Enums;

namespace CardGame.API.Controllers.Responses;
public class PlayRoundResponse
{
    public IDictionary<PlayerType,Card> Cards { get; }
    public PlayerType Winner { get; }
    
    public PlayRoundResponse(IDictionary<Player, Card> cards, Player? winner)
    {
        Cards = new Dictionary<PlayerType, Card>();
        foreach (var card in cards)
        {
            Cards[card.Key.PlayerType] = card.Value;
        }
        Winner = winner.PlayerType;
    }

}