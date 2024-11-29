using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISystemStatusRepository
    {

        Task SaveSystemStatusAsync(SystemStatus systemStatus);

        Task<List<SystemStatus>> GetAllSystemStatusAsync();
    }
}
