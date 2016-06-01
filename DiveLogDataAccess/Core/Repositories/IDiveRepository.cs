using DiveLogDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiveLogDataAccess.Core.Repositories
{
    public interface IDiveRepository : IRepository<Dive>
    {
        IEnumerable<Dive> GetTopLatestDives(int count);

    }
}
