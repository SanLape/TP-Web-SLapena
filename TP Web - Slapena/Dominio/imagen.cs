using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class imagen
    {
        public int idImagen { get; set; }
        public int idArticulo { get; set; }
        public string urlImagen { get; set; }
        public override string ToString()
        {
            return urlImagen;
        }
    }
}
