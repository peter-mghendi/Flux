using System;
using Fluxor;
using Flux.Store.State;
using Blazored.LocalStorage;

namespace Flux.Store.Features.Todos
{
    public class TodosFeature : Feature<TodosState>
    {
        public override string GetName() => "Todos";

        protected override TodosState GetInitialState() 
        {
            return new TodosState(false, null, null, null);
        }
    }
}