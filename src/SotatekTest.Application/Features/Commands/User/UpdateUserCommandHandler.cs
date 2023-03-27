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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetRepository<Domain.Entities.User>().GetByIdAsync(request.id);
            if (user is null)
                throw new Exception("user not found");
            user.Email = request.model.Email;
            user.FullName = request.model.FullName;
            user.Age = request.model.Age;
            user.Phone = request.model.Phone;
            await _unitOfWork.GetRepository<Domain.Entities.User>().UpdateAsync(user);
            await _unitOfWork.CommitTransactionAsync();
            return Unit.Value;
        }
    }
}
