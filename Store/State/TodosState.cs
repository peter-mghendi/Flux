using Flux.Models.Todos;
using System.Collections.Generic;

namespace Flux.Store.State
{
    public class TodosState : RootState
    {
        public TodosState(bool isLoading, string? currentErrorMessage, IEnumerable<TodoDTO>? currentTodos, TodoDTO? currentTodo) 
            : base(isLoading, currentErrorMessage)
        {
            CurrentTodos = currentTodos;
            CurrentTodo = currentTodo;
        }

        public IEnumerable<TodoDTO>? CurrentTodos { get; }

        public TodoDTO? CurrentTodo { get; }
    }
}