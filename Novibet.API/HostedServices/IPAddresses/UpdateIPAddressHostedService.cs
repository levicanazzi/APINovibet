using Microsoft.Extensions.Options;
using Novibet.Application.IPAdresses.CommandSide.Commands.UpSert;
using Novibet.Infrastructure.Core.HostedServices;

namespace Novibet.API.HostedServices.IPAddresses
{
    public class UpdateIPAddressHostedService : RequestServiceBase<UpsertIPCommand>
    {
        public UpdateIPAddressHostedService(IServiceProvider serviceProvider, ILogger<HostedServiceBase> logger, IOptions<HostedServiceSettings> settings)
        : base(serviceProvider, logger, settings)
        {
        }
    }
}
