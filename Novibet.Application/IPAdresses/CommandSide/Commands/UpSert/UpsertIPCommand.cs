using CSharpFunctionalExtensions;
using MediatR;
using Novibet.Infrastructure.Core.Models;

namespace Novibet.Application.IPAdresses.CommandSide.Commands.UpSert
{
    public class UpsertIPCommand : IRequest<Result<Unit, Error>>
    {
        public UpsertIPCommand()
        {
            DataExecucao = DateTimeOffset.Now;
        }

        public DateTimeOffset DataExecucao { get; set; }
    }
}
