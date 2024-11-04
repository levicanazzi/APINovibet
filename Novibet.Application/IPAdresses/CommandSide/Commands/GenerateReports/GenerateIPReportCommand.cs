using MediatR;
using Novibet.Application.IPAdresses.CommandSide.QuerySide;

namespace Novibet.Application.IPAdresses.CommandSide.Commands.GenerateReports
{
    public class GenerateIPReportCommand : IRequest<IEnumerable<IPReportCountryViewModel>>
    {
        public List<string>? TwoLetterCodes { get; set; } = new List<string>();
    }
}
