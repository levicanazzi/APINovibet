using MediatR;
using Novibet.Application.IPAdresses.CommandSide.QuerySide;
using Novibet.Application.IPAdresses.CommandSide.Repositories;
using Novibet.Domain.Notifications;
using Novibet.Infrastructure.Core.Commands;
using Novibet.Infrastructure.Core.Repositories;

namespace Novibet.Application.IPAdresses.CommandSide.Commands.GenerateReports
{
    public class GenerateIPReportCommandHandler : BaseCommandHandler, IRequestHandler<GenerateIPReportCommand, IEnumerable<IPReportCountryViewModel>>
    {
        private readonly IIPAddressRepository _iPAddressRepository;
        public GenerateIPReportCommandHandler(IUnitOfWork uow, IMediator bus, INotificationHandler<DomainNotification> notifications, IIPAddressRepository iPAddressRepository) : base(uow, bus, notifications)
        {
            _iPAddressRepository = iPAddressRepository;
        }

        public async Task<IEnumerable<IPReportCountryViewModel>> Handle(GenerateIPReportCommand request, CancellationToken cancellationToken)
        {
            var result = await _iPAddressRepository.IPReportCountry(request.TwoLetterCodes);

            if (result is null)
            {
                return Error<IEnumerable<IPReportCountryViewModel>>("No item found");
            }

            return Success<IEnumerable<IPReportCountryViewModel>>(result);
        }
    }
}
