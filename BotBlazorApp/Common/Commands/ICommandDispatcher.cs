namespace BotBlazorApp.Common.Commands;

public interface ICommandDispatcher
{
    Task ExecuteAsync<T>(T command) where T : class, ICommand;

    Task<TResult> ExecuteAsync<TCommand, TResult>(TCommand command) where TCommand : class, ICommand<TResult>;
}