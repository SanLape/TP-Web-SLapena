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
    public partial class Default : System.Web.UI.Page
    {
        public List<articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            ListaArticulos = negocio.listar();

            if(!IsPostBack)
            {

            }

            repRepetidor.DataSource = ListaArticulos;
            repRepetidor.DataBind();
        }
    }
}