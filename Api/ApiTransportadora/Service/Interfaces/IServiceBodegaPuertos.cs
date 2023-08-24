using Model.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IServiceBodegaPuertos
    {
        ModelResponse CrearBodegaPuerto(List<ModelBodegaPuerto> cliente, string Conexion);
        ModelResponse ValidarCamposBodegasPuertos(List<ModelBodegaPuerto> bodegaPuertos);
    }
}
