using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class imagenNegocio
    {
        List<imagen> lista = new List<imagen>();
        AccesoDatos datos = new AccesoDatos();

        public List<imagen> listar()
        {
            try
            {
                datos.setConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    imagen imgAux = new imagen();

                    imgAux.idImagen = (int)datos.Lector["Id"];
                    imgAux.idArticulo = (int)datos.Lector["IdArticulo"];
                    imgAux.urlImagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(imgAux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
