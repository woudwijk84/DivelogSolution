using DiveLogDataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiveLogDataAccess.Core
{
    interface IUnitOfWork : IDisposable
    {
        IDiveRepository Dives { get; }

        int Complete();
    }
}
