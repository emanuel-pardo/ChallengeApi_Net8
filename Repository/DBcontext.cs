using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options)
       : base(options)
        { }
        public DbSet<SystemStatus> SystemStatuses { get; set; }
    }

}

