using Novibet.Application.Countries.CommandSide.Aggregates;
using Novibet.Application.Countries.CommandSide.QuerySide;
using Novibet.Infrastructure.Core.Repositories;

namespace Novibet.Application.Countries.CommandSide.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        ValueTask<CountryViewModel> FindByIPAsync(string ip);
        ValueTask<Country> FindByNameAsync(string name, string twoLetterCode, string threeLetterCode);
        ValueTask InsertAsync(Country country);
        ValueTask UpdateAsync(Country country);
    }
}
