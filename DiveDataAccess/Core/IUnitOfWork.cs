using DiveDataAccess.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiveDataAccess.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDiveRepository Dives { get; }
        int Complete();
    }
}
