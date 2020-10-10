using Fluxor;
using Microsoft.Extensions.Logging;
using Flux.Models.Todos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Flux.Store.Features.Shared.Actions;
using Flux.Store.Features.Todos.Actions.LoadTodos;

namespace Flux.Store.Features.Shared.Effects
{
    public class StoreInitializedsEffect : Effect<StoreInitializedAction>
    {
        private readonly ILogger<StoreInitializedsEffect> _logger;

        private readonly ILocalStorageService _localStorage;

        public StoreInitializedsEffect(
            ILogger<StoreInitializedsEffect> logger,
            ILocalStorageService localStorage
        )
        => (_logger, _localStorage) = (logger, localStorage);

        protected async override Task HandleAsync(StoreInitializedAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Initializing store...");
                
                // Console.WriteLine(_localStorage is null);
                var todos = await _localStorage.GetItemAsync<IEnumerable<TodoDTO>>("todos");
                dispatcher.Dispatch(new InitializeTodosAction(todos));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error initializing store, reason: {e.Message}");
                dispatcher.Dispatch(new LoadTodosFailureAction(e.Message));
            }
        }
    }
}