using Model.Clases;
using Service.Clases;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTransportadora.InyeccionD
{
    public class BodegasPuertos
    {
        IServiceBodegaPuertos serviceBodegaPuertos;

        public BodegasPuertos(ServiceBodegasPuertos serviceBodegasPuertos)
        {
            this.serviceBodegaPuertos = serviceBodegasPuertos;
        }

        public ModelResponse CrearBodegaPuerto(List<ModelBodegaPuerto> cliente, string Conexion)
        {
           return this.CrearBodegaPuerto(cliente, Conexion);
        }
    }
}