using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
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

            if (!IsPostBack)
            {
                cargar();
            }
            else
            {

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string nombreBuscar = txtBuscar.Text;

            ListaArticulos = ListaArticulos.FindAll(x => x.nombre.ToUpper().Contains(nombreBuscar.ToUpper()));
            cargar();

        }
        private void cargar()
        {
            repRepetidor.DataSource = ListaArticulos;
            repRepetidor.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int idArt = int.Parse(((Button)sender).CommandArgument);
            articuloNegocio negocio = new articuloNegocio();

            if (Session["listaCarrito"] == null)
            {
                Session.Add("listaCarrito",negocio.listar(idArt));
            }
            else
            {
                Session.Add("listaCarrito", negocio.listar(idArt));
            }
        }
        
        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            if (Session.Count > 0)
            {
                string idArt = ((Button)sender).CommandArgument;
                Session.Remove(idArt);

            }
        }
    }
}