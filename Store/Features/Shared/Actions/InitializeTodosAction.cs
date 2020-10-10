using System.Collections.Generic;
using Flux.Models.Todos;

namespace Flux.Store.Features.Shared.Actions
{
    public class InitializeTodosAction
    {
        public InitializeTodosAction(IEnumerable<TodoDTO> todos) =>
            Todos = todos;

        public IEnumerable<TodoDTO> Todos { get; }
    }
}