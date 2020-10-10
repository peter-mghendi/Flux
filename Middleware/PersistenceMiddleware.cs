using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Flux.Store.Features.Todos.Actions.LoadTodos;
using Fluxor;
using Newtonsoft.Json;
using AbstractMiddleware = Fluxor.Middleware;

namespace Flux.Middleware
{
    public class PersistenceMiddleware : AbstractMiddleware
    {
        private IStore? Store;

        private readonly ILocalStorageService _localStorage;

        public PersistenceMiddleware(ILocalStorageService localStorage)
		{
            _localStorage = localStorage;
		}

        public override Task InitializeAsync(IStore store)
        {
            Store = store;
            Console.WriteLine(nameof(InitializeAsync));
            return Task.CompletedTask;
        }

        public async override void AfterDispatch(object action)
        {
            if (action is LoadTodosSuccessAction a)
            {
                var state = Store!.Features["Todos"].GetState();
                await _localStorage.SetItemAsync<object>("Todos", state);
            }
        }
    }
}