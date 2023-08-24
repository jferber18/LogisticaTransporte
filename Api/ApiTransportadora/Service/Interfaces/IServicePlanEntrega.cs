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
        ModelResponse ListarPlanEntrega(string Conexion, int IdEntrega = 0, int IdProducto = 0, int IdTipoLogistica = 0, int IdBodega = 0, int IdCliente = 0);
        ModelResponse CrearPlanEntrega(ModelPlanEntrega cliente, string Conexion);
        ModelResponse ValidarCamposPlanEntrega(ModelPlanEntrega planEntrega);
    }
}
