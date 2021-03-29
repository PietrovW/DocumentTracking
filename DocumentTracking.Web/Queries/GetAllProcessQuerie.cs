using DocumentTracking.Entities;
using MediatR;
using System.Collections.Generic;

namespace DocumentTracking.Queries
{
    public class GetAllProcessQuerie : IRequest<IList<Process>>
    {
    }
}
