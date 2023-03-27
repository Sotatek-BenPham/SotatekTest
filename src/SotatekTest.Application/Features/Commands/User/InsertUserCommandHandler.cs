using AutoMapper;
using MediatR;
using SotatekTest.Application.Dtos.User;
using SotatekTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Application.Features.Commands.User
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InsertUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<int> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<InsertUserDto,Domain.Entities.User>(request.request);
            await _unitOfWork.GetRepository<Domain.Entities.User>().AddAsync(newUser);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            return newUser.Id;
        }
    }
}
