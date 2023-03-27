using MediatR;
using SotatekTest.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Application.Features.Queries.User
{
    public record GetUserQuery(SelectUserFilter? filter) :IRequest<IEnumerable<Domain.Entities.User>>;
}
