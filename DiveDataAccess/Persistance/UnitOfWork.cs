using DiveDataAccess.Core;
using DiveDataAccess.Core.IRepositories;
using DiveDataAccess.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiveDataAccess.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DiveContext _context;
        public IDiveRepository Dives { get; private set; }

        public UnitOfWork(DiveContext context)
        {
            _context = context;
            Dives = new DiveRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}