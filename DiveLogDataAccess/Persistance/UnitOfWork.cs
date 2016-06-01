using DiveLogDataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiveLogDataAccess.Core.Repositories;
using DiveLogDataAccess.Persistance.Repositories;

namespace DiveLogDataAccess.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DiveContext _context;

        public UnitOfWork(DiveContext context)
        {
            _context = context;
            Dives = new DiveRepository(_context);
        }


        public IDiveRepository Dives { get; private set; }

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