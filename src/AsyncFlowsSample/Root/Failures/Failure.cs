using System.Net;
using static System.Environment;

namespace AsyncFlows.Modules.Root.Failures;

public record Failure(
    HttpStatusCode StatusCode,
    string? Message = default,
    string? Expression = default);

public class FailureException
    : InvalidOperationException
{
    public FailureException(Failure failure)
        : this(failure, default) { }

    public FailureException(Failure failure, Exception? inner)
        : base(failure.Message, inner)

    {
        Failure = failure;
        StatusCode = failure.StatusCode;
    }

    public Failure Failure { get; }
    public HttpStatusCode StatusCode { get; }

    public override string ToString()
        => $"{Failure}{NewLine}{base.ToString()}";
}
