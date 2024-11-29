using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SystemStatusRepository : ISystemStatusRepository
    {

        private readonly DBcontext _dbcontext;

        public SystemStatusRepository(DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Task<List<SystemStatus>> GetAllSystemStatusAsync()
        {
           return _dbcontext.SystemStatuses.ToListAsync();
        }

        public async Task SaveSystemStatusAsync(SystemStatus systemStatus)
        {
            
            _dbcontext.SystemStatuses.Add(systemStatus.New());
            await _dbcontext.SaveChangesAsync();
        }
    }
}
