using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
	public class categoriaNegocio
	{
		List<categoria> lista = new List<categoria>();
		AccesoDatos datos = new AccesoDatos();
		public List<categoria> listar()
		{
			try
			{
				datos.setConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					categoria auxCat = new categoria();

					auxCat.idCategoria = (int)datos.Lector["Id"];
					auxCat.nombre = (string)datos.Lector["Descripcion"];

					lista.Add(auxCat);
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
		public void agregar(categoria nuevo)
		{
			string insert = "INSERT INTO CATEGORIAS (Descripcion) VALUES (@nombre)";
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
			string consutla = "DELETE FROM CATEGORIAS WHERE Id = @ID";
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
