using CardGame.Application.CardGameService;
using CardGame.Application.Interfaces;
using CardGame.Domain.Entities;
using CardGame.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CardGame.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IGameManager, GameManager>();
        services.AddSingleton<IDeck, Deck>();
        return services;
    }
}