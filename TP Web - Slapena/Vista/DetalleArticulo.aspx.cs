using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Vista
{
    public partial class formArticulo : System.Web.UI.Page
    {
        public List<articulo> listArt { get; set; }
        public articulo art { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            articuloNegocio negocio = new articuloNegocio();
            listArt = negocio.listar(int.Parse(Request.QueryString["id"]));
            art = listArt[0];

        }
    }
}