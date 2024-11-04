using Dapper;
using Microsoft.EntityFrameworkCore;
using Novibet.Application.Countries.CommandSide.Aggregates;
using Novibet.Application.IPAdresses.CommandSide.Aggregates;
using Novibet.Repository.Mappings.Countries;
using Novibet.Repository.Mappings.IPAddresses;
using System.Dynamic;

namespace Novibet.Repository.Context
{
    public class NovibetDbContext : DbContext
    {
        public NovibetDbContext(DbContextOptions<NovibetDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<IPAddress> IPAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryTbMap());
            modelBuilder.ApplyConfiguration(new IPAddressesTbMap());

            base.OnModelCreating(modelBuilder);
        }

        public async ValueTask<IEnumerable<TResult>> SelectFromRawSqlAsync<TResult>(string sql, Dictionary<string, object> parameters)
        where TResult : class
        {
            var param = new ExpandoObject() as IDictionary<string, object>;

            parameters.ToList().ForEach(x => param.Add(x.Key, x.Value));
            return await Database.GetDbConnection().QueryAsync<TResult>(sql, parameters);
        }
    }
}