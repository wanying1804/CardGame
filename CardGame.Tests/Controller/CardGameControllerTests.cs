using CardGame.API.Controllers;
using CardGame.API.Controllers.Responses;
using CardGame.Application.Interfaces;
using CardGame.Domain.Entities;
using CardGame.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CardGame.Tests.Controller;

public class CardGameControllerTests
{
    private readonly Mock<IGameManager> _gameManagerMock;
    private readonly GameController _gameController;

    public CardGameControllerTests()
    {
        _gameManagerMock = new Mock<IGameManager>();
        _gameController = new GameController(_gameManagerMock.Object);
    }

    [Fact]
    public void ShouldReturnsOkResultWithSuccessMessage_WhenResetAndShuffleTheDeck()
    {
        // Arrange
        _gameManagerMock.Setup(x => x.ShuffleDeck());
        _gameManagerMock.Setup(x => x.ResetGame());

        // Act
        IActionResult result = _gameController.ResetAndShuffleDeck();

        // Assert
        _gameManagerMock.Verify(d => d.ShuffleDeck(), Times.Once);
        _gameManagerMock.Verify(d => d.ResetGame(), Times.Once);
        var okResult = Assert.IsType<OkObjectResult>(result);
        var successMessage = Assert.IsType<SuccessMessage>(okResult.Value);
        Assert.Equal("Deck reset and shuffled successfully.", successMessage.Message);
    }
    
    [Fact]
    public void ShouldReturnsOkResponse_WhenPlayOneRound()
    {
        // Arrange
        var cards = new Dictionary<Player, Card>
        {
            { new Player(PlayerType.Human), new Card(Suit.Clubs, 2) },
            { new Player(PlayerType.Computer), new Card(Suit.Diamonds, 3) }
        };
        var winner = new Player(PlayerType.Computer);

        _gameManagerMock.Setup(g => g.DealCards()).Returns(cards);
        _gameManagerMock.Setup(g => g.GetWinnerForCurrentRound()).Returns(winner);

        // Act
        var result = _gameController.PlayOneRound();

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<PlayRoundResponse>(okResult.Value);

        var response = Assert.IsType<PlayRoundResponse>(okResult.Value);
        Assert.Equal(winner.PlayerType, response.Winner);
    }
    
    [Fact]
    public void GetCurrentScores_ReturnsOkResponseWithScoreResponse()
    {
        // Arrange
        var playerScore = 10;
        var computerScore = 5;
        var scores = new Scores(playerScore, computerScore);

        _gameManagerMock.Setup(g => g.GetCurrentScores()).Returns(scores);

        // Act
        var result = _gameController.GetCurrentScores();

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<ScoreResponse>(okResult.Value);

        var response = Assert.IsType<ScoreResponse>(okResult.Value);
        Assert.Equal(playerScore, response.PlayerScore);
        Assert.Equal(computerScore, response.ComputerScore);
    }
}