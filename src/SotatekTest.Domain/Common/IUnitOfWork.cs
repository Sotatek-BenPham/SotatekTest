using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Domain.Common
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        Task<int> CommitTransactionAsync(CancellationToken cancellationToken = default, Guid? internalCommandId = null);

        Task RollBackTransactionAsync();
    }
}
