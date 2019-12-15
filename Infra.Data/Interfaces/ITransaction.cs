using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Data.Interfaces
{
    public interface ITransaction : IDisposable
    {
        Task CommitAsync(CancellationToken ct);
    }
}
