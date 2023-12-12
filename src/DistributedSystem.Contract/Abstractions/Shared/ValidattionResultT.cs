namespace DistributedSystem.Contract.Abstractions.Shared
{
    public sealed class ValidattionResult<TValue> : Result<TValue>, IValidattionResult
    {
        private ValidattionResult(Error[] errors) : base(default, false, IValidattionResult.ValidationError) => Errors = errors;
        public Error[] Errors { get; }
        public static ValidattionResult<TValue> WithErrors(Error[] errors) => new(errors);
    }
}
