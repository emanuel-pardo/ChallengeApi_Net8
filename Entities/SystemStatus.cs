using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SystemStatus : GenericEntity
    {
      
        private string _plataformName = "";
        private string _version = "";
        private string _status = "";
               
        public string PlataformName { get { return _plataformName; } set { _plataformName = value; } }
        public string Version { get { return _version; } set { _version = value; } }
        public string Status { get { return _status; } set { _status = value; } }
     
        public SystemStatus New()
        {
            this.Id = Guid.NewGuid();
            this.FechaCreacion = DateTime.Now;
            return this;
        }

    }
}
