using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class carro : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            List<articulo> temp = (List<articulo>)Session["listaCarrito"];
            lblCantidad.Text = temp.Count.ToString();

        }
    }
}