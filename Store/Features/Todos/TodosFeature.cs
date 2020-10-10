using Fluxor;
using Flux.Store.State;

namespace Flux.Store.Features.Todos
{
    public class TodosFeature : Feature<TodosState>
    {
        public override string GetName() => "Todos";

        protected override TodosState GetInitialState() =>
            new TodosState(false, null, null, null);
    }
}