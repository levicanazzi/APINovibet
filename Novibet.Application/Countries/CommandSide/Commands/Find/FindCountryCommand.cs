using MediatR;
using Novibet.Application.Countries.CommandSide.QuerySide;

namespace Novibet.Application.Countries.CommandSide.Commands.Find
{
    public class FindCountryCommand : IRequest<CountryViewModel>
    {
        public string IP { get; set; }
    }
}

