using DiveLogDataAccess.Core.Repositories;
using DiveLogDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiveLogDataAccess.Persistance.Repositories
{
    public class DiveRepository : Repository<Dive>, IDiveRepository
    {
        public DiveRepository(DiveContext context) : base(context)
        {
        }

        public DiveContext DiveContext
        {
            get { return _Context as DiveContext; }
        }

        public IEnumerable<Dive> GetTopLatestDives(int count = 5)
        {
            return DiveContext.Dives.OrderByDescending(a => a.Date)
                                    .Take(count)
                                    .ToList();
        }
    }
}