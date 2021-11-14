using AutoMapper;
using DocumentTracking.ApplicationCore.Entities;
using DocumentTracking.Infrastructure.Command;
using DocumentTracking.Infrastructure.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class CreateProcessCommandHandler : IRequestHandler<CreateProcessCommand, Process>
    {
        private readonly DocumentTrackingContext dbContext;
        private readonly IMapper mapper;
        public CreateProcessCommandHandler(DocumentTrackingContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Process> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
        {
            Process destination = mapper.Map<CreateProcessCommand, Process>(request);
            var result = await dbContext.Process.AddAsync(destination, cancellationToken);
            return result.Entity;
        }
    }
}
