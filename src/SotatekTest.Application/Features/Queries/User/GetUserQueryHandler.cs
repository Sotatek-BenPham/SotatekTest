using AutoMapper;
using MediatR;
using SotatekTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Application.Features.Queries.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<Domain.Entities.User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Domain.Entities.User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.User, bool>> predicate = null;
            Func<IQueryable<Domain.Entities.User>, IOrderedQueryable<Domain.Entities.User>> orderBy = null;
            List<Expression<Func<Domain.Entities.User, object>>> includes = new List<Expression<Func<Domain.Entities.User, object>>>();

            if (request.filter != null)
            {
                if (!string.IsNullOrEmpty(request.filter.Email))
                {
                    predicate = (u => u.Email == request.filter.Email);
                }

                if (!string.IsNullOrEmpty(request.filter.Phone))
                {
                    if (predicate == null)
                    {
                        predicate = (u => u.Phone == request.filter.Phone);
                    }
                    else
                    {
                        predicate = (u => u.Phone == request.filter.Phone && u.Email == request.filter.Email);
                    }
                }

                if (!string.IsNullOrEmpty(request.filter.SortBy))
                {
                    switch (request.filter.SortBy.ToLower())
                    {
                        case "email": 
                            {
                                orderBy = q => q.OrderByDescending(x => x.Email);
                                break;
                            }
                        case "phone":
                            {
                                orderBy = q => q.OrderByDescending(x => x.Phone);
                                break;
                            }
                        case "fullname":
                            {
                                orderBy = q => q.OrderByDescending(x => x.FullName);
                                break;
                            }
                        case "age":
                            {
                                orderBy = q => q.OrderByDescending(x => x.Age);
                                break;
                            }
                        default: 
                            {
                                orderBy = q => q.OrderByDescending(x => x.Id);
                                break;
                            }
                    }                   
                }
            }
            var userList = await _unitOfWork.GetRepository<Domain.Entities.User>().GetAsync(predicate, orderBy, includes);
            return userList;
        }
    }
}
