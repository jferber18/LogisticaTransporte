using Model.Clases;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Service.Clases
{
    public class ServiceCliente : IServiceCliente
    {
        List<SqlParameter> Parametros = new List<SqlParameter>();
        ModelConexion Co = new ModelConexion();
        ModelFunciones Funciones = new ModelFunciones();

        public ModelResponse CrearCliente(ModelCliente cliente, string Conexion)
        {
            ModelResponse response = new ModelResponse();
            string SP = "CREAR_Cliente";
            try
            {
                ModelResponse res = ValidarCamposCliente(cliente);
                if (res.Estado)
                {
                    Parametros.Clear();
                    Parametros.Add(new SqlParameter("@NombreCliente", cliente.NombreCliente));
                    Parametros.Add(new SqlParameter("@IdTipoDoc", cliente.IdTipoDoc));
                    Parametros.Add(new SqlParameter("@Telefono", cliente.Telefono));
                    Parametros.Add(new SqlParameter("@Celular", cliente.Celular));
                    Parametros.Add(new SqlParameter("@Email", cliente.Email));
                    Parametros.Add(new SqlParameter("@Direccion", cliente.Direccion));
                    DataTable Tbl = Co.EjecutarProcedimientoAlmacenado(SP, Parametros, Conexion);

                    int IdGenerado = int.Parse(Tbl.Rows[0]["IdGenerado"].ToString());

                    SP = "CREAR_Producto";
                    foreach (var item in cliente.Productos)
                    {
                        Parametros.Clear();
                        Parametros.Add(new SqlParameter("@IdGenerado", IdGenerado));
                        Parametros.Add(new SqlParameter("@NombreProducto", item.NombreProducto));
                        Parametros.Add(new SqlParameter("@TipoLogistica", item.TipoLogistica));
                        Parametros.Add(new SqlParameter("@Activo", item.Activo));
                        DataTable Tbl2 = Co.EjecutarProcedimientoAlmacenado(SP, Parametros, Conexion);
                    }

                    response.mensaje = "El cliente se creó correctamente";
                    response.Estado = true;
                }
                else
                {
                    response = res;
                }

            }
            catch (Exception ex)
            {
                response.mensaje = "Error al crear el cliente";
                response.excepcion = ex.Message;
                response.Estado = false;
            }
            return response;
        }

        public ModelResponse ListarClientes(string Conexion, int IdCliente = 0)
        {
            ModelResponse response = new ModelResponse();
            List<ModelCliente> modelCliente = new List<ModelCliente>();
            string SP = "LISTAR_Clientes";
            try
            {
                Parametros.Clear();
                Parametros.Add(new SqlParameter("@IdCliente", IdCliente));
                DataTable Tbl = Co.EjecutarProcedimientoAlmacenado(SP, Parametros, Conexion);
                int Id = 0;
                foreach (DataRow item in Tbl.Rows)
                {
                    ModelCliente cliente = new ModelCliente();

                    cliente.IdCliente = int.Parse(item["IdCliente"].ToString());
                    cliente.NombreCliente = item["NombreCliente"].ToString();
                    cliente.IdTipoDoc = int.Parse(item["IdTipoDoc"].ToString());
                    cliente.Telefono = int.Parse(item["Telefono"].ToString());
                    cliente.Celular = int.Parse(item["Celular"].ToString());
                    cliente.Email = item["Email"].ToString();
                    cliente.Direccion = item["Direccion"].ToString();

                    SP = "LISTAR_Productos";
                    Parametros.Clear();
                    Parametros.Add(new SqlParameter("@IdCliente", cliente.IdCliente));
                    Parametros.Add(new SqlParameter("@IdTipoLogistica", 0));
                    DataTable Tbl2 = Co.EjecutarProcedimientoAlmacenado(SP, Parametros, Conexion);
                    foreach (DataRow item2 in Tbl2.Rows)
                    {
                        Producto producto = new Producto();
                        producto.IdProducto = int.Parse(item2["IdProducto"].ToString());
                        producto.NombreProducto = item2["NombreProducto"].ToString();
                        producto.TipoLogistica = int.Parse(item2["IdTipoLogistica"].ToString());
                        producto.Activo = item2["Activo"].ToString() == "True" ? 1 : 0;

                        cliente.Productos.Add(producto);
                    }
                    modelCliente.Add(cliente);
                }

                response.mensaje = "Consulta ejecutada correctamente";
                response.response = modelCliente;
                response.Estado = false;
            }
            catch (Exception ex)
            {
                response.mensaje = "Error al listar los clientes";
                response.excepcion = ex.Message;
                response.Estado = false;
            }
            return response;
        }

        public ModelResponse ValidarCamposCliente(ModelCliente cliente)
        {
            ModelResponse response = new ModelResponse();
            try
            {
                response.mensaje = "Validación campos cliente";
                if (string.IsNullOrEmpty(cliente.NombreCliente))
                {

                    response.excepcion = "El campo NombreCliente no puede estar vacío";
                    response.Estado = false;
                    return response;
                }
                else if (cliente.IdTipoDoc == 0)
                {
                    response.excepcion = "El campo IdTipoDoc no puede estar vacío o ser cero";
                    response.Estado = false;
                    return response;
                }
                else if (cliente.Telefono == 0)
                {
                    response.excepcion = "El campo Telefono no puede estar vacío o ser cero";
                    response.Estado = false;
                    return response;
                }
                else if (cliente.Celular == 0)
                {
                    response.excepcion = "El campo Celular no puede estar vacío o ser cero";
                    response.Estado = false;
                    return response;
                }
                else if (string.IsNullOrEmpty(cliente.Email) || Funciones.ComprobarFormatoEmail(cliente.Email))
                {
                    response.excepcion = "El campo Email no puede estar vacío o no cumple con el formato de correo";
                    response.Estado = false;
                    return response;
                }
                else if (string.IsNullOrEmpty(cliente.Direccion))
                {
                    response.excepcion = "El campo Direccion no puede estar vacío";
                    response.Estado = false;
                    return response;
                }
                else if (cliente.Productos.Count == 0)
                {
                    response.excepcion = "El campo Productos no puede estar vacío";
                    response.Estado = false;
                    return response;
                }
                else
                {
                    int con = 0;
                    foreach (var item in cliente.Productos)
                    {
                        if (string.IsNullOrEmpty(item.NombreProducto))
                        {
                            response.excepcion = $"El campo Productos[{con.ToString()}].NombreProducto no puede estar vacío";
                            response.Estado = false;
                            return response;
                        }
                        else if (item.TipoLogistica == 0)
                        {
                            response.excepcion = $"El campo Productos[{con.ToString()}].TipoLogistica no puede estar vacío o ser cero";
                            response.Estado = false;
                            return response;
                        }
                        else if (item.Activo == 0)
                        {
                            response.excepcion = $"El campo Productos[{con.ToString()}].Activo no puede estar vacío o ser cero";
                            response.Estado = false;
                            return response;
                        }
                        con += 1;
                    }
                }


                response.mensaje = "Validación correcta";
                response.Estado = true;

            }
            catch (Exception ex)
            {
                response.mensaje = "Error al validar los campos de cliente";
                response.excepcion = ex.Message;
                response.Estado = false;
            }
            return response;
        }
    }
}
