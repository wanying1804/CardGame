# Card Game

This Project is designed to implement a simple card comparison game between player and computer


## Running locally with Docker
TBD

## Structure

THe project apply Clean Architecture principles

CardGame.Domain: This project contains all the domain entities, value objects, and interfaces that define the core business logic of the card game. 

CardGame.Application: This project implements the application layer, which contains the use cases or application-specific logic of the card game. It depends on the domain layer and orchestrates the interaction between the domain and infrastructure layers. It includes classes like GameManager, and any other application services or use case classes.

CardGame.Api: This project contains all the api controllers of the card game.

CardGame.Tests: This project contains all the unit tests for your application and domain logic. It should reference the appropriate projects (e.g., Application, Domain) to test the functionality of your code.

- CardGame.Domain
  - Entities
    - Card.cs
    - Deck.cs
    - Player.cs
      ...
  - Enums
    - Suit.cs
      ...
  - Interfaces
    - IDeck.cs
      ...
- CardGame.Application
  - GameManager.cs
  - Interfaces
    - IGameManager.cs
    ...
- CardGame.Api 
  - CardGameController

