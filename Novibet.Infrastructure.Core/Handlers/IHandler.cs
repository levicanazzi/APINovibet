using CSharpFunctionalExtensions;

namespace Novibet.Infrastructure.Core.Handlers
{
    public interface IHandler<TRequest>
    {
        ValueTask<Result> Handle(TRequest request);
    }
}
