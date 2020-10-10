using Fluxor;
using Flux.Store.State;
using Flux.Store.Features.Shared.Actions;

namespace Flux.Store.Features.Shared.Reducers
{
    public static class InitializeActionsReducer
    {
        [ReducerMethod]
        public static TodosState InitializeTodosAction(TodosState state, InitializeTodosAction action) =>
           new TodosState(false, null, action.Todos, state.CurrentTodo);
    }
}