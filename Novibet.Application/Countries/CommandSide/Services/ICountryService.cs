using CSharpFunctionalExtensions;
using Novibet.Application.Countries.CommandSide.Aggregates;
using Novibet.Application.IPAdresses.CommandSide.Aggregates;

namespace Novibet.Application.Countries.CommandSide.Services
{
    public interface ICountryService
    {
        ValueTask<Result<Country>> Integration(IPAddress ipAddress);
    }
}
