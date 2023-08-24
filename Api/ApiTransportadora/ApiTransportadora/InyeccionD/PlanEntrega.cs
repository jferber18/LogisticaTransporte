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
    }
}