using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Target.Entities.DTO
{
    public class Response
    {
        public bool success { get; set; }
        public object? payload { get; set; }
    }
}
