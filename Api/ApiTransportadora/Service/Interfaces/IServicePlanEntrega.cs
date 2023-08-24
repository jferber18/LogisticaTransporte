using Model.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IServicePlanEntrega
    {
        ModelResponse CrearPlanEntrega(ModelPlanEntrega cliente, string Conexion);
        ModelResponse ValidarCamposPlanEntrega(ModelPlanEntrega planEntrega);
    }
}
