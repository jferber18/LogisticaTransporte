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
    [RoutePrefix("api/BodegasPuertos")]
    public class BodegasPuertosController : ApiController
    {
        private IServiceBodegaPuertos serviceBodegaPuertos = new ServiceBodegasPuertos();
        private string Conexion = "DB_Connection";
        ModelResponse response;


        [AllowAnonymous]
        public HttpResponseMessage Get(int IdBodegaPuerto = 0, int IdCliente = 0, int IdTipoLogistica = 0)
        {
            try
            {
                Conexion = ConfigurationManager.ConnectionStrings[Conexion].ToString();
                response = this.serviceBodegaPuertos.ListarBodegaPuerto(Conexion, IdBodegaPuerto, IdCliente, IdTipoLogistica);
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
                response.mensaje = "Error al crear la bodega o puerto";
                response.excepcion = ex.Message;
                response.Estado = false;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        [AllowAnonymous]
        public HttpResponseMessage Post(List<ModelBodegaPuerto> modelBodegaPuerto)
        {
            try
            {
                Conexion = ConfigurationManager.ConnectionStrings[Conexion].ToString();
                response = this.serviceBodegaPuertos.CrearBodegaPuerto(modelBodegaPuerto, Conexion);
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
                response.mensaje = "Error al crear la bodega o puerto";
                response.excepcion = ex.Message;
                response.Estado = false;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }
    }
}
