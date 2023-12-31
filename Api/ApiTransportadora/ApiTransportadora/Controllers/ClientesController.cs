﻿using ApiTransportadora.InyeccionD;
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
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {
        private IServiceCliente serviceCliente = new ServiceCliente();
        private string Conexion = "DB_Connection";
        ModelResponse response;

        [AllowAnonymous]
        //[Autorizar]
        public HttpResponseMessage Get(int Id = 0)
        {
            try
            {
                Conexion = ConfigurationManager.ConnectionStrings[Conexion].ToString();
                response = this.serviceCliente.ListarClientes(Conexion, Id);
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
                response.mensaje = "Error al listar los cliente";
                response.excepcion = ex.Message;
                response.Estado = false;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        [AllowAnonymous]
        //[Autorizar]
        public HttpResponseMessage Post(ModelCliente Cliente)
        {
            try
            {
                Conexion = ConfigurationManager.ConnectionStrings[Conexion].ToString();
                response = this.serviceCliente.CrearCliente(Cliente, Conexion);
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
                response.mensaje = "Error al crear el cliente";
                response.excepcion = ex.Message;
                response.Estado = false;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        [AllowAnonymous]
        //[Authorize(Roles = "admin")]
        // DELETE: api/Clientes/5
        public void Delete(int id)
        {

        }
    }
}
