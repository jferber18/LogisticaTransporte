using Model.Clases;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTransportadora.InyeccionD
{
    public class Clientes
    {
        private IServiceCliente serviceCliente;

        public Clientes(IServiceCliente SC)
        {
            this.serviceCliente = SC;
        }

        public ModelResponse CrearCliente(ModelCliente cliente, string Conexion)
        {
           return  this.serviceCliente.CrearCliente(cliente, Conexion);
        }
    }
}