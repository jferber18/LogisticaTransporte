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

        public ModelResponse CrearCliente(ModelCliente cliente,string Conexion)
        {
            ModelResponse response = new ModelResponse();
            string SP = "CREAR_Cliente";
            try
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
                return response;
            }
            catch (Exception ex)
            {
                response.mensaje = "Error al crear el cliente";
                response.excepcion = ex.Message;
                response.Estado = false;
            }
            return response;
        }
    }
}
