using MediatR;
using SotatekTest.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Application.Features.Commands.User
{
    public record UpdateUserCommand(int id, InsertUserDto model): IRequest<Unit>;   
}
