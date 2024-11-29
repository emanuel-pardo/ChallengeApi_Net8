using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ResponseDTO
    {
        public const string LeyendaOk = "OK";
        public const string LeyendaError = "Error";
        public string PlataformName { get; set; } = "";
        public string Version { get; set; } = "";
        public string Status { get; set; } = "";

    }
}
