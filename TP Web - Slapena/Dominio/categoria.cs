using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class categoria
    {
        [DisplayName("NUMERO")]
        public int idCategoria { get; set; }
        [DisplayName("NOMBRE")]
        public string nombre { get; set; }
        public override string ToString()
        {
            return nombre;
        }
    }
}
