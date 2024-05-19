using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class articuloNegocio
    {
        List<articulo> lista = new List<articulo>();
        AccesoDatos datos = new AccesoDatos();
        public List<articulo> listar()
        {
            string select = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Id marcID, M.Descripcion marcDesc, C.Id catID, C.Descripcion catDesc, Precio, I.Id imgID, I.ImagenUrl imgUrl";
            string from = " FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES AS I ON I.IdArticulo = A.Id";

            try
            {
                datos.setConsulta(select + from);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulo aux = new articulo();
                    aux.idArticulo = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    aux.marca = new marca();
                    aux.marca.idMarca = (int)datos.Lector["marcID"];
                    aux.marca.nombre = (string)datos.Lector["marcDesc"];

                    aux.categoria = new categoria();
                    aux.categoria.idCategoria = (int)datos.Lector["catID"];
                    aux.categoria.nombre = (string)datos.Lector["catDesc"];

                    aux.imagen = new imagen();
                    if (!(datos.Lector["imgID"] is DBNull))
                    {
                        aux.imagen.idImagen = (int)datos.Lector["imgID"];
                        aux.imagen.urlImagen = (string)datos.Lector["imgUrl"];
                    }

                    lista.Add(aux);

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
        public List<articulo> listar(int idArticulo)
        {
            string select = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Id marcID, M.Descripcion marcDesc, C.Id catID, C.Descripcion catDesc, Precio, I.Id imgID, I.ImagenUrl imgUrl";
            string from = " FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES AS I ON I.IdArticulo = A.Id";
            string where = " WHERE A.Id = @idArticulo";

            try
            {
                datos.setConsulta(select + from + where);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulo aux = new articulo();
                    aux.idArticulo = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    aux.marca = new marca();
                    aux.marca.idMarca = (int)datos.Lector["marcID"];
                    aux.marca.nombre = (string)datos.Lector["marcDesc"];

                    aux.categoria = new categoria();
                    aux.categoria.idCategoria = (int)datos.Lector["catID"];
                    aux.categoria.nombre = (string)datos.Lector["catDesc"];

                    aux.imagen = new imagen();
                    if (!(datos.Lector["imgID"] is DBNull))
                    {
                        aux.imagen.idImagen = (int)datos.Lector["imgID"];
                        aux.imagen.urlImagen = (string)datos.Lector["imgUrl"];
                    }

                    lista.Add(aux);

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

        public void agregar(articulo nuevo)
        {
            string insertArticulo = "INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)";
            //string insertImagen = "INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)";

            try
            {
                datos.setConsulta(insertArticulo);
                datos.setearParametro("@Codigo", nuevo.codigo);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.setearParametro("@IdMarca", nuevo.marca.idMarca);
                datos.setearParametro("@IdCategoria", nuevo.categoria.idCategoria);
                datos.setearParametro("@Precio", nuevo.precio);

                datos.ejecutarAccion();
                /*
				datos.setConsulta(insertImagen);
				datos.setearParametro("@IdArticulo", idArticuloInsertado);
				datos.setearParametro("@ImagenUrl", nuevo.imagen.urlImagen);

				datos.ejecutarAccion();
				*/
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
        public void modificar(articulo modificar)
        {
            string consutla = "UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcat, Precio = @precio WHERE Id = @id";
            try
            {
                datos.setConsulta(consutla);
                datos.setearParametro("@codigo", modificar.codigo);
                datos.setearParametro("@nombre", modificar.nombre);
                datos.setearParametro("@descripcion", modificar.descripcion);
                datos.setearParametro("@idmarca", modificar.marca.idMarca);
                datos.setearParametro("@idcat", modificar.categoria.idCategoria);
                datos.setearParametro("@precio", modificar.precio);
                datos.setearParametro("@id", modificar.idArticulo);

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
            string consutla = "DELETE FROM ARTICULOS WHERE Id = @ID";
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

        public List<articulo> filtrar(string campo, string criterio, string filtro)
        {
            string select = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Id marcID, M.Descripcion marcDesc, C.Id catID, C.Descripcion catDesc, Precio, I.Id imgID, I.ImagenUrl imgUrl";
            string from = " FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES AS I ON I.IdArticulo = A.Id";
            string where;
            string consulta = select + from;

            if (campo == "PRECIO")
            {
                switch (criterio)
                {
                    case "MAYOR A":
                        where = " WHERE Precio > " + filtro;
                        break;
                    case "MENOR A":
                        where = " where Precio < " + filtro;
                        break;
                    default:
                        where = " where  Precio = " + filtro;
                        break;
                }
            }
            else
            {
                // hacer para coigo, nombre, escripcion
                switch (criterio)
                {
                    case "COMIENZA CON":
                        where = " where " + campo + " like '" + filtro + "%'";
                        break;
                    case "TERMINA CON":
                        where = " where " + campo + " like '%" + filtro + "'";
                        break;
                    default:
                        where = " where " + campo + " like '%" + filtro + "%'";
                        break;
                }
            }
            consulta = select + from + where;
            try
            {
                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulo aux = new articulo();
                    aux.idArticulo = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    aux.marca = new marca();
                    aux.marca.idMarca = (int)datos.Lector["marcID"];
                    aux.marca.nombre = (string)datos.Lector["marcDesc"];

                    aux.categoria = new categoria();
                    aux.categoria.idCategoria = (int)datos.Lector["catID"];
                    aux.categoria.nombre = (string)datos.Lector["catDesc"];

                    aux.imagen = new imagen();
                    if (!(datos.Lector["imgID"] is DBNull))
                    {
                        aux.imagen.idImagen = (int)datos.Lector["imgID"];
                        aux.imagen.urlImagen = (string)datos.Lector["imgUrl"];
                    }

                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
/*
"CODIGO"
"NOMBRE"
"DESCRIPCION"
"PRECIO"
*/
/*
"MAYOR A "
"MENOR A "
"IGUAL A "
                

"COMIENZA CON "
"TERMINA CON "
"CONTIENE  "

*/
/*
 
			string consulta = "INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES('" + nuevo.codigo + "', '" + nuevo.nombre + "', '" + nuevo.descripcion + "', @IdMarca, @IdCategoria, " + nuevo.precio +")";
			try
			{
				datos.setConsulta(consulta);
				datos.setearParametro("@IdMarca", nuevo.marca.idMarca);
                datos.setearParametro("@IdCategoria", nuevo.categoria.idCategoria);
                datos.ejecutarAccion();

			}
 */
