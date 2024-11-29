using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class GenericEntity
    {
        private Guid _id;
        private DateTime _fechaCreacion;
        public Guid Id { get { return _id; } set { _id = value; } }
        public DateTime FechaCreacion { get { return _fechaCreacion; } set { _fechaCreacion = value; } }
    }
}
