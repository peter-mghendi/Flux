using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Flux.Models.Todos;
using Flux.Store.Features.Todos.Actions.LoadTodos;
using Flux.Store.State;
using Fluxor;
using AbstractMiddleware = Fluxor.Middleware;

namespace Flux.Middleware
{
    public class PersistenceMiddleware : AbstractMiddleware
    {
        private IStore? Store;

        private readonly ISyncLocalStorageService _localStorage;

        public PersistenceMiddleware(ISyncLocalStorageService localStorage)
		{
            _localStorage = localStorage;
		}

        public override Task InitializeAsync(IStore store)
        {
            Store = store;
            return Task.CompletedTask;
        }

        public override void AfterDispatch(object action)
        {
            if (action is LoadTodosSuccessAction)
            {
                var state = Store!.Features["Todos"].GetState();

                if (state is TodosState todosState)
                {
                    _localStorage.SetItem<IEnumerable<TodoDTO>>("todos", 
                        todosState.CurrentTodos ?? new List<TodoDTO>());
                }
            }
        }
    }
}