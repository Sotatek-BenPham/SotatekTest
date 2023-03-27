using AutoMapper;
using MediatR;
using SotatekTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Application.Features.Commands.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetRepository<Domain.Entities.User>().GetByIdAsync(request.id);
            if (user is null)
                throw new Exception("user not found");
            await _unitOfWork.GetRepository<Domain.Entities.User>().DeleteAsync(user);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
