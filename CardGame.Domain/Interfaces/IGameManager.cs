﻿using CardGame.Domain.Entities;

namespace CardGame.Domain.Interfaces;

public interface IGameManager
{
    void ShuffleDeck();
    void ResetGame();
    Scores GetCurrentScores();
    IDictionary<Player, Card> DealCards();
    Player? GetWinnerForAllRound();
    Player? GetWinnerForCurrentRound();
}