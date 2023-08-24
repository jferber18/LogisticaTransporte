using Model.Clases;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTransportadora.InyeccionD
{
    public class PlanEntrega
    {
        private IServicePlanEntrega servicePlanEntrega;

        public PlanEntrega(IServicePlanEntrega servicePlanEntrega)
        {
            this.servicePlanEntrega = servicePlanEntrega;
        }

        public ModelResponse CrearPlanEntrega(ModelPlanEntrega cliente, string Conexion)
        {
            return this.servicePlanEntrega.CrearPlanEntrega(cliente, Conexion);
        }

        public ModelResponse ListarPlanEntrega(string Conexion, int IdEntrega = 0, int IdProducto = 0, int IdTipoLogistica = 0, int IdBodega = 0, int IdCliente = 0)
        {
            return this.servicePlanEntrega.ListarPlanEntrega(Conexion,IdEntrega,IdProducto,IdTipoLogistica,IdBodega,IdCliente);
        }
    }
}