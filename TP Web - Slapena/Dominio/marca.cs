using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Dominio
{
    public class marca
    {
        [DisplayName("NUMERO")]
        public int idMarca { get; set; }
        [DisplayName("NOMBRE")]
        public string nombre { get; set; }
        public override string ToString()
        {
            return nombre;
        }
    }
}
