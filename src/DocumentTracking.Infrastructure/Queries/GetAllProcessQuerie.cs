using DocumentTracking.ApplicationCore.Entities;
using MediatR;
using System.Collections.Generic;

namespace DocumentTracking.Infrastructure.Queries
{
    public class GetAllProcessQuerie : IRequest<IList<Process>>
    {
    }
}
