#nullable disable

using Fluxor;
using Microsoft.Extensions.Logging;
using Flux.Models.Todos;
using Flux.Store.Features.Todos.Actions.LoadTodos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Flux.Store.Features.Todos.Effects
{
    public class LoadTodosEffect : Effect<LoadTodosAction>
    {
        private readonly ILogger<LoadTodosEffect> _logger;
        private readonly HttpClient _httpClient;

        public LoadTodosEffect(ILogger<LoadTodosEffect> logger, HttpClient httpClient) =>
            (_logger, _httpClient) = (logger, httpClient);

        protected override async Task HandleAsync(LoadTodosAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Loading todos...");

                // Add a little extra latency for dramatic effect...
                await Task.Delay(TimeSpan.FromMilliseconds(1000));
                var todosResponse = await _httpClient.GetFromJsonAsync<IEnumerable<TodoDTO>>("todos");

                _logger.LogInformation("Todos loaded successfully!");
                dispatcher.Dispatch(new LoadTodosSuccessAction(todosResponse));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error loading todos, reason: {e.Message}");
                dispatcher.Dispatch(new LoadTodosFailureAction(e.Message));
            }

        }
    }
}