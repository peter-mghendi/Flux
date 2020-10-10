namespace Flux.Store.Features.Shared.Actions
{
    public abstract class FailureAction
    {
        protected FailureAction(string errorMessage) => 
            ErrorMessage = errorMessage;

        public string ErrorMessage { get; }
    }
}