using Microsoft.EntityFrameworkCore;
using Novibet.Application.Countries.CommandSide.Aggregates;
using Novibet.Application.Countries.CommandSide.QuerySide;
using Novibet.Application.Countries.CommandSide.Repositories;
using Novibet.Repository.Context;

namespace Novibet.Repository.Countries
{
    public class CountryRepository : ICountryRepository
    {
        private readonly NovibetDbContext _context;
        public CountryRepository(NovibetDbContext context)
        {
            _context = context;
        }

        public async ValueTask InsertAsync(Country country)
        {
            await _context.Countries.AddAsync(country);

            await Task.CompletedTask;
        }

        public async ValueTask UpdateAsync(Country country)
        {
            _context.Countries.Attach(country);

            await Task.CompletedTask;
        }

        public async ValueTask<CountryViewModel> FindByIPAsync(string ip)
        {
            var result = await (from country in _context.Countries
                                join ipAddresses in _context.IPAddresses on country.Id equals ipAddresses.CountryId
                                where ipAddresses.IP == ip
                                select new CountryViewModel
                                {
                                    CountryName = country.Name,
                                    TwoLetterCode = country.TwoLetterCode,
                                    ThreeLetterCode = country.ThreeLetterCode
                                }
                                ).FirstOrDefaultAsync();

            return result;
        }

        public async ValueTask<Country> FindByNameAsync(string name, string twoLetterCode, string threeLetterCode)
        {
            return await _context.Countries
                                .FirstOrDefaultAsync(c => c.Name == name &&
                                                    c.TwoLetterCode == twoLetterCode &&
                                                    c.ThreeLetterCode == threeLetterCode);
        }

        public async ValueTask<Country> FindAsync(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
