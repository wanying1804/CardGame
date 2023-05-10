using CardGame.Domain.Enums;
using CardGame.Domain.Interfaces;

namespace CardGame.Domain.Entities;

public class Player
{
    public PlayerType PlayerType { get; init; }

    public Player(PlayerType playerType)
    {
        PlayerType = playerType;
    }
}
