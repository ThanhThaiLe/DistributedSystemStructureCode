namespace DistributedSystem.Contract.Abstractions.Shared
{
    public interface IValidattionResult
    {
        public static readonly Error ValidationError = new Error(
            "ValidationError",
            "A validation problem occurred");
        Error[] Errors { get; }
    }
}
