using MediatR;
using Microsoft.AspNetCore.Mvc;
using Novibet.API.Controllers.Base;
using Novibet.Application.Countries.CommandSide.Commands.Find;
using Novibet.Application.Countries.CommandSide.Repositories;
using Novibet.Application.IPAdresses.CommandSide.Commands.GenerateReports;
using Novibet.Domain.Notifications;
using Novibet.Repository.Context;

namespace Novibet.API.Controllers.v1.CountriesController
{
    [Route("v1/countries")]
    [ApiController]
    public class CountryController : ApiController
    {
        private readonly ICountryRepository _countryRepository;
        private readonly NovibetDbContext _context;
        public CountryController(INotificationHandler<DomainNotification> notifications, IMediator mediator, ICountryRepository countryRepository, NovibetDbContext context) : base(notifications, mediator)
        {
            _countryRepository = countryRepository;
            _context = context;
        }

        [HttpGet]
        [Route("{ip}")]
        public async ValueTask<IActionResult> FindByIp([FromRoute] FindCountryCommand request)
        {
            return await Dispatch(request);
        }

        [HttpPost]
        [Route("report")]
        public async ValueTask<IActionResult> Report([FromBody] GenerateIPReportCommand request)
        {
            return await Dispatch(request);
        }
    }
}
