using Model.Clases;
using Service.Clases;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTransportadora.Controllers
{
    [RoutePrefix("api/PlanEntrega")]
    public class PlanEntregaController : ApiController
    {
        private IServicePlanEntrega servicePlanEntrega = new ServicePlanEntrega();
        private string Conexion = "DB_Connection";
        ModelResponse response;

        [AllowAnonymous]
        //[Authorize]
        public HttpResponseMessage Get(int IdEntrega = 0, int IdProducto = 0, int IdTipoLogistica = 0, int IdBodega = 0, int IdCliente = 0)
        {
            try
            {
                Conexion = ConfigurationManager.ConnectionStrings[Conexion].ToString();
                response = this.servicePlanEntrega.ListarPlanEntrega(Conexion,IdEntrega, IdProducto, IdTipoLogistica, IdBodega, IdCliente);
                if (response.Estado)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
            }
            catch (Exception ex)
            {
                response.mensaje = "Error al crear el plan de entrega";
                response.excepcion = ex.Message;
                response.Estado = false;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        public HttpResponseMessage Post(ModelPlanEntrega modelPlanEntrega )
        {
            try
            {
                Conexion = ConfigurationManager.ConnectionStrings[Conexion].ToString();
                response = this.servicePlanEntrega.CrearPlanEntrega(modelPlanEntrega, Conexion);
                if (response.Estado)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
            }
            catch (Exception ex)
            {
                response.mensaje = "Error al crear el plan de entrega";
                response.excepcion = ex.Message;
                response.Estado = false;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }
    }
}
