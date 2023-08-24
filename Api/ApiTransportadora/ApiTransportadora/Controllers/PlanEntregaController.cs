﻿using Model.Clases;
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

        [HttpPost]
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

        // GET: api/PlanEntrega
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PlanEntrega/5
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/PlanEntrega/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PlanEntrega/5
        public void Delete(int id)
        {
        }
    }
}