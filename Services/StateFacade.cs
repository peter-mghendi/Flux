using Fluxor;
using Microsoft.Extensions.Logging;
// using Flux.Store.Features.Todos.Actions.LoadTodoDetail;
using Flux.Store.Features.Todos.Actions.LoadTodos;

namespace Flux.Services
{
    public class StateFacade
    {
        private readonly ILogger<StateFacade> _logger;
        private readonly IDispatcher _dispatcher;

        public StateFacade(ILogger<StateFacade> logger, IDispatcher dispatcher) =>
            (_logger, _dispatcher) = (logger, dispatcher);

        public void LoadTodos()
        {
            _logger.LogInformation("Issuing action to load todos...");
            _dispatcher.Dispatch(new LoadTodosAction());
        }
    }
}