using Flux.Store.Features.Shared.Actions;

namespace Flux.Store.Features.Todos.Actions.LoadTodos
{
    public class LoadTodosFailureAction : FailureAction
    {
        public LoadTodosFailureAction(string errorMessage) 
            : base(errorMessage)
        {
        }
    }
}