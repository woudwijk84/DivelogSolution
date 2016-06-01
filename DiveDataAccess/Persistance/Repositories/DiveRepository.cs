using DiveDataAccess.Core.IRepositories;
using DiveDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiveDataAccess.Persistance.Repositories
{
    public class DiveRepository : Repository<Dive>, IDiveRepository
    {
        public DiveRepository(DiveContext context) : base(context)
        {
        }

        public IEnumerable<Dive> GetLatestDives(int count)
        {
            throw new NotImplementedException();
        }
    }
}