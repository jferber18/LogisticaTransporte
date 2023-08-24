using Model.Clases;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Clases
{
    public class ServiceBodegasPuertos : IServiceBodegaPuertos
    {
        List<SqlParameter> Parametros = new List<SqlParameter>();
        ModelConexion Co = new ModelConexion();

        public ModelResponse CrearBodegaPuerto(List<ModelBodegaPuerto> bodegaPuertos, string Conexion)
        {
            ModelResponse response = new ModelResponse();
            string SP = "CREAR_BodegaPuerto";
            try
            {
                ModelResponse res = ValidarCamposBodegasPuertos(bodegaPuertos);
                if (res.Estado)
                {
                    int p = 0;
                    foreach (var item in bodegaPuertos)
                    {
                        Parametros.Clear();
                        Parametros.Add(new SqlParameter("@IdCliente", item.IdCliente));
                        Parametros.Add(new SqlParameter("@IdTipoLogistica", item.IdTipoLogistica));
                        Parametros.Add(new SqlParameter("@Nombre", item.Nombre));
                        Parametros.Add(new SqlParameter("@Direccion", item.Direccion));
                        Parametros.Add(new SqlParameter("@Activo", item.Activo));
                        DataTable Tbl = Co.EjecutarProcedimientoAlmacenado(SP, Parametros, Conexion);
                        if (Tbl.Rows.Count == 0)
                        {
                            response.mensaje = "Error al crear la  bodega o puerto";
                            response.excepcion = $"No se pudo guardar la bodega o puerto en le pocisión {p.ToString()}";
                            response.Estado = false;
                            return response;
                        }
                        p += 1;
                    }
                    response.mensaje = "Las bodegas y puertos se guardaron correctamente";
                    response.Estado = true;
                }
                else
                {
                    response = res;
                }
            }
            catch (Exception ex)
            {
                response.mensaje = "Error al crear la bodega o puerto";
                response.excepcion = ex.Message;
                response.Estado = false;
            }
            return response;
        }

        public ModelResponse ListarBodegaPuerto(string Conexion, int IdBodegaPuerto = 0, int IdCliente = 0, int IdTipoLogistica = 0)
        {
            ModelResponse response = new ModelResponse();
            List<ModelBodegaPuerto> modelBodegaPuertos = new List<ModelBodegaPuerto>();
            string SP = "LISTAR_BodegasPuertos";
            try
            {
                Parametros.Clear();
                Parametros.Add(new SqlParameter("@IdBodegaPuerto", IdBodegaPuerto));
                Parametros.Add(new SqlParameter("@IdCliente", IdCliente));
                Parametros.Add(new SqlParameter("@IdTipoLogistica", IdTipoLogistica));
                DataTable Tbl = Co.EjecutarProcedimientoAlmacenado(SP, Parametros, Conexion);

                foreach (DataRow item in Tbl.Rows)
                {
                    ModelBodegaPuerto bodegaPuerto = new ModelBodegaPuerto();
                    bodegaPuerto.IdBodegaPuerto = int.Parse(item["IdBodegaPuerto"].ToString());
                    bodegaPuerto.IdCliente = int.Parse(item["IdCliente"].ToString());
                    bodegaPuerto.IdTipoLogistica = int.Parse(item["IdTipoLogistica"].ToString());
                    bodegaPuerto.Nombre = item["Nombre"].ToString();
                    bodegaPuerto.Direccion = item["Direccion"].ToString();

                    modelBodegaPuertos.Add(bodegaPuerto);
                }

                response.mensaje = "Consulta ejecutada correctamente";
                response.response = modelBodegaPuertos;
                response.Estado = true;

            }
            catch (Exception ex)
            {
                response.mensaje = "Error al listar las bodegas y puertos";
                response.excepcion = ex.Message;
                response.Estado = false;
            }
            return response;
        }

        public ModelResponse ValidarCamposBodegasPuertos(List<ModelBodegaPuerto> bodegaPuertos)
        {
            ModelResponse response = new ModelResponse();
            try
            {
                response.mensaje = "Validación campos plan entrega";
                int con = 0;
                foreach (var item in bodegaPuertos)
                {
                    if (item.IdCliente == 0)
                    {
                        response.excepcion = $"El campo [{con.ToString()}].IdCliente no puede estar vacío o ser cero";
                        response.Estado = false;
                        return response;
                    }
                    else if (item.IdTipoLogistica == 0)
                    {
                        response.excepcion = "El campo [{con.ToString()}].IdTipoLogistica no puede estar vacío o ser cero";
                        response.Estado = false;
                        return response;
                    }
                    else if (string.IsNullOrEmpty(item.Nombre))
                    {
                        response.excepcion = "El campo [{con.ToString()}].Nombre no puede estar vacío";
                        response.Estado = false;
                        return response;
                    }
                    else if (string.IsNullOrEmpty(item.Direccion))
                    {
                        response.excepcion = "El campo [{con.ToString()}].Direccion no puede estar vacío";
                        response.Estado = false;
                        return response;
                    }
                    else if (item.Activo == 0)
                    {
                        response.excepcion = "El campo [{con.ToString()}].Activo no puede estar vacío o ser cero";
                        response.Estado = false;
                        return response;
                    }

                    con += 1;
                }

                response.mensaje = "Validación correcta";
                response.Estado = true;

            }
            catch (Exception ex)
            {
                response.mensaje = "Error al validar los campos de bodegas o puertos";
                response.excepcion = ex.Message;
                response.Estado = false;
            }
            return response;

        }
    }
}
