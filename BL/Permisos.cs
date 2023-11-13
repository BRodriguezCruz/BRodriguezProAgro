using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Permisos
    {
        public int IdPermiso { get; set; }
        public Estado Estado { get; set; }
        public Usuario Usuario { get; set; }
        public  List<object>? ListPermisos { get; set; }
    }
}
