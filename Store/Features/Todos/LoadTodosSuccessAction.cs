using Flux.Models.Todos;
using System.Collections.Generic;

namespace Flux.Store.Features.Todos.Actions.LoadTodos
{
    public class LoadTodosSuccessAction
    {
        public LoadTodosSuccessAction(IEnumerable<TodoDTO> todos) =>
            Todos = todos;

        public IEnumerable<TodoDTO> Todos { get; }
    }
}