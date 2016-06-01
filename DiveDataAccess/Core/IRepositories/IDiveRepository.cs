using DiveDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiveDataAccess.Core.IRepositories
{
    public interface IDiveRepository : IRepository<Dive>
    {
        //Dive GetDive(int id);
        IEnumerable<Dive> GetLatestDives(int count); 
        
    }
}
