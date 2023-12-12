namespace DistributedSystem.Contract.Abstractions.Shared
{
    public sealed class ValidattionResult : Result, IValidattionResult
    {
        private ValidattionResult(Error[] errors) : base(false, IValidattionResult.ValidationError) => Errors = errors;
        public Error[] Errors { get; }
        public static ValidattionResult WithErrors(Error[] errors) => new(errors);
    }
}
