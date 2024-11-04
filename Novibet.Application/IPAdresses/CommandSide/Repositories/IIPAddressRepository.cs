using Novibet.Application.IPAdresses.CommandSide.Aggregates;
using Novibet.Application.IPAdresses.CommandSide.QuerySide;
using Novibet.Infrastructure.Core.Repositories;

namespace Novibet.Application.IPAdresses.CommandSide.Repositories
{
    public interface IIPAddressRepository : IRepository<IPAddress>
    {
        ValueTask UpdateAsync(IPAddress ipAddress);
        ValueTask<IPAddress> FindByIPAsync(string ipAddress);
        ValueTask<IEnumerable<IPAddress>> FindAllAsync();
        ValueTask<IEnumerable<IPReportCountryViewModel>> IPReportCountry(IEnumerable<string>? twoLetterCodes);
    }
}
