namespace BotBlazorApp.Common.Commands;

internal sealed class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceScopeFactory serviceScopeFactory;

    public CommandDispatcher(IServiceScopeFactory serviceScopeFactory)
    {
        this.serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<TResult> ExecuteAsync<TCommand, TResult>(TCommand command)
        where TCommand : class, ICommand<TResult>
    {
        using var scope = serviceScopeFactory.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
        return await handler.HandleAsync(command);
    }

    public async Task ExecuteAsync<T>(T command) where T : class, ICommand
    {
        using var scope = serviceScopeFactory.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<T>>();
        await handler.HandleAsync(command);
    }
}