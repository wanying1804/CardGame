using CardGame.API.Controllers;
using CardGame.API.Controllers.Responses;
using CardGame.Application.Interfaces;
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
    public void ShuffleDeck_ReturnsOkResultWithSuccessMessage()
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
}