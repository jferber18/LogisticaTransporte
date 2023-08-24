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
    public class ServicePlanEntrega : IServicePlanEntrega
    {
        List<SqlParameter> Parametros = new List<SqlParameter>();
        ModelConexion Co = new ModelConexion();

        public ModelResponse CrearPlanEntrega(ModelPlanEntrega planEntrega, string Conexion)
        {
            ModelResponse response = new ModelResponse();
            string SP = "CREAR_PlanEntrega";

            try
            {
                ModelResponse res = ValidarCamposPlanEntrega(planEntrega);
                if (res.Estado)
                {
                    Parametros.Clear();
                    Parametros.Add(new SqlParameter("@IdProducto", planEntrega.IdProducto));
                    Parametros.Add(new SqlParameter("@IdTipoLogistica", planEntrega.IdTipoLogistica));
                    Parametros.Add(new SqlParameter("@CantidadProducto", planEntrega.CantidadProducto));
                    Parametros.Add(new SqlParameter("@FechaRegistro", Convert.ToDateTime(planEntrega.FechaRegistro)));
                    Parametros.Add(new SqlParameter("@FechaEntrega", Convert.ToDateTime(planEntrega.FechaEntrega)));
                    Parametros.Add(new SqlParameter("@IdBodega", planEntrega.IdBodega));
                    Parametros.Add(new SqlParameter("@PlacaVehiculo", planEntrega.IdTipoLogistica == 1 ? planEntrega.PlacaVehiculo : ""));
                    Parametros.Add(new SqlParameter("@NumeroGuia", planEntrega.NumeroGuia == "" ? GenerarAlfaNumerico10() : planEntrega.NumeroGuia));
                    Parametros.Add(new SqlParameter("@NumeroFlota", planEntrega.IdTipoLogistica == 2 ? planEntrega.NumeroFlota : ""));
                    DataTable Tbl = Co.EjecutarProcedimientoAlmacenado(SP, Parametros, Conexion);
                    if (Tbl.Rows.Count > 0)
                    {
                        response.mensaje = "El plan de entrega se guardó correctamente";
                        response.Estado = true;
                    }
                    else
                    {
                        response.mensaje = "Error al guardar el plan de entrega";
                        response.excepcion = $"No se pudo guardar el plan de entrega, el registro está vacío";
                        response.Estado = false;
                    }
                }
                else
                {
                    response = res;
                }
            }
            catch (Exception ex)
            {
                response.mensaje = "Error al crear el plan de entrega";
                response.excepcion = ex.Message;
                response.Estado = false;
            }
            return response;
        }

        public ModelResponse ListarPlanEntrega(string Conexion, int IdEntrega = 0, int IdProducto = 0, int IdTipoLogistica = 0, int IdBodega = 0, int IdCliente = 0)
        {
            ModelResponse response = new ModelResponse();
            List<ModelPlanEntrega> modelPlanEntrega = new List<ModelPlanEntrega>();
            string SP = "LISTAR_PlanesEntrega";
            try
            {
                Parametros.Clear();
                Parametros.Add(new SqlParameter("@IdEntrega", IdEntrega));
                Parametros.Add(new SqlParameter("@IdProducto", IdProducto));
                Parametros.Add(new SqlParameter("@IdTipoLogistica", IdTipoLogistica));
                Parametros.Add(new SqlParameter("@IdBodega", IdBodega));
                Parametros.Add(new SqlParameter("@IdCliente", IdCliente));
                DataTable Tbl = Co.EjecutarProcedimientoAlmacenado(SP, Parametros, Conexion);

                foreach (DataRow item in Tbl.Rows)
                {
                    ModelPlanEntrega PlanEntrega = new ModelPlanEntrega();

                    PlanEntrega.IdEntrega = int.Parse(item["IdEntrega"].ToString());
                    PlanEntrega.IdTipoLogistica = int.Parse(item["IdTipoLogistica"].ToString());
                    PlanEntrega.CantidadProducto = int.Parse(item["CantidadProducto"].ToString());
                    PlanEntrega.FechaRegistro = item["FechaRegistro"].ToString();
                    PlanEntrega.FechaEntrega = item["FechaEntrega"].ToString();
                    PlanEntrega.PrecioEnvioFijo = decimal.Parse(item["PrecioEnvioFijo"].ToString());
                    PlanEntrega.PorcenDescuento = decimal.Parse(item["PorcenDescuento"].ToString());
                    PlanEntrega.PrecioEnvioReal = decimal.Parse(item["PrecioEnvioReal"].ToString());
                    PlanEntrega.NumeroGuia = item["NumeroGuia"].ToString();
                    PlanEntrega.PlacaVehiculo = item["PlacaVehiculo"].ToString();
                    PlanEntrega.NumeroFlota = item["IdBodega"].ToString();
                    modelPlanEntrega.Add(PlanEntrega);
                }

                response.mensaje = "Consulta ejecutada correctamente";
                response.response = modelPlanEntrega;
                response.Estado = true;

            }
            catch (Exception ex)
            {
                response.mensaje = "Error al listar los planes de entrega";
                response.excepcion = ex.Message;
                response.Estado = false;
            }
            return response;
        }

        public ModelResponse ValidarCamposPlanEntrega(ModelPlanEntrega planEntrega)
        {
            ModelResponse response = new ModelResponse();
            try
            {
                if (planEntrega.IdProducto == 0)
                {
                    response.mensaje = "Validación campos plan entrega";
                    response.excepcion = "El campo IdProducto no puede estar vacío o ser cero";
                    response.Estado = false;
                    return response;
                }
                else if (planEntrega.IdTipoLogistica == 0)
                {
                    response.mensaje = "Validación campos plan entrega";
                    response.excepcion = "El campo IdTipoLogistica no puede estar vacío o ser cero";
                    response.Estado = false;
                    return response;
                }
                else if (planEntrega.CantidadProducto == 0)
                {
                    response.mensaje = "Validación campos plan entrega";
                    response.excepcion = "El campo CantidadProducto no puede estar vacío o ser cero";
                    response.Estado = false;
                    return response;
                }
                else if (string.IsNullOrEmpty(planEntrega.FechaRegistro))
                {
                    response.mensaje = "Validación campos plan entrega";
                    response.excepcion = "El campo FechaRegistro no puede estar vacío";
                    response.Estado = false;
                    return response;
                }
                else if (planEntrega.IdBodega == 0)
                {
                    response.mensaje = "Validación campos plan entrega";
                    response.excepcion = "El campo IdBodega no puede estar vacío o ser cero";
                    response.Estado = false;
                    return response;
                }
                else if (planEntrega.IdTipoLogistica == 1 && string.IsNullOrEmpty(planEntrega.PlacaVehiculo))
                {
                    response.mensaje = "Validación campos plan entrega";
                    response.excepcion = "El campo PlacaVehiculo no puede estar vacío por que el tipo logística es 1";
                    response.Estado = false;
                    return response;
                }
                else if (planEntrega.IdTipoLogistica == 2 && string.IsNullOrEmpty(planEntrega.NumeroFlota))
                {
                    response.mensaje = "Validación campos plan entrega";
                    response.excepcion = "El campo NumeroFlota no puede estar vacío por que el tipo logística es 2";
                    response.Estado = false;
                    return response;
                }

                try
                {
                    Convert.ToDateTime(planEntrega.FechaRegistro);
                }
                catch (Exception)
                {
                    response.mensaje = "Validación campos plan entrega";
                    response.excepcion = "El campo FechaRegistro no cumple el formato para fecha";
                    response.Estado = false;
                    return response;
                }

                try
                {
                    Convert.ToDateTime(planEntrega.FechaEntrega);
                }
                catch (Exception)
                {
                    response.mensaje = "Validación campos plan entrega";
                    response.excepcion = "El campo FechaEntrega no cumple el formato para fecha";
                    response.Estado = false;
                    return response;
                }

                response.mensaje = "Validación correcta";
                response.Estado = true;

            }
            catch (Exception ex)
            {
                response.mensaje = "Error al validar los campos de plan de entrega";
                response.excepcion = ex.Message;
                response.Estado = false;
            }
            return response;
        }

        public string GenerarAlfaNumerico10()
        {
            try
            {
                //ABCDEFGHIJKLMNOPQRSTUVWXYZ
                var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[10];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);
                return finalString;
            }
            catch (Exception)
            {
                return "0";
            }
        }
    }
}
