# Card Game

This Project is designed to implement a simple card comparison game between player and computer


## Running locally with Docker
```
docker-compose build
docker-compose up
```
then you can access the api from
```http://localhost:8000/swagger/index.html```

## Api route

- ```/api/game/reset-shuffle```

  This route is used to reset the game and shuffle the deck. When a request is sent to this endpoint, the game manager will reset the game state, including the scores and any played rounds, and shuffle the deck of cards. It returns a success message indicating that the deck has been reset and shuffled successfully.
- ```/api/game/play-round```

  This route is used to play one round of the game. When a request is sent to this endpoint, the game manager will deal cards for both the human player and the computer player, and determine the winner for the round. The response will include the cards dealt to each player and the winner of the round.
- ```/api/game/all-scores```

  This route is used to get the scores for both the human player and the computer player. When a request is sent to this endpoint, the game manager will retrieve the current scores and return them in the response. The response will include the scores for the human player and the computer player.
- ```/api/game/all-rounds-winner```

  This route is used to get the winner for all the rounds played so far. When a request is sent to this endpoint, the game manager will determine the winner for all the rounds and return the overall winner. The response will include the player type (Human or Computer) of the overall winner.

## Structure

THe project apply Clean Architecture principles

- CardGame.Domain: 

  This project contains all the domain entities, value objects, and interfaces that define the core business logic of the card game. 

- CardGame.Application: 

  This project implements the application layer, which contains the use cases or application-specific logic of the card game. It depends on the domain layer and orchestrates the interaction between the domain and infrastructure layers. It includes classes like GameManager, and any other application services or use case classes.

- CardGame.Api: 

  This project contains all the api controllers of the card game.

- CardGame.Tests: 

  This project contains all the unit tests for your application and domain logic. It should reference the appropriate projects (e.g., Application, Domain) to test the functionality of your code.


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

