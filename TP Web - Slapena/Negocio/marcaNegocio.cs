using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class marcaNegocio
    {
        List<marca> lista = new List<marca>();
        AccesoDatos datos = new AccesoDatos();

        public List<marca> listar()
        {
            try
            {
                datos.setConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    marca auxMar = new marca();

                    auxMar.idMarca = (int)datos.Lector["Id"];
                    auxMar.nombre = (string)datos.Lector["Descripcion"];

                    lista.Add(auxMar);
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
        public void agregar(marca nuevo)
        {
            string insert = "INSERT INTO MARCAS (Descripcion) VALUES (@nombre)";
            try
            {
                datos.setConsulta(insert);
                datos.setearParametro("@nombre", nuevo.nombre);

                datos.ejecutarAccion();
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
        public void eliminar(int id)
        {
            string consutla = "DELETE FROM MARCAS WHERE Id = @ID";
            try
            {
                datos.setConsulta(consutla);
                datos.setearParametro("@ID", id);
                datos.ejecutarAccion();
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
