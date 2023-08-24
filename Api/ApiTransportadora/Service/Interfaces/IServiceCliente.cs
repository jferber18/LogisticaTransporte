using Model.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IServiceCliente
    {
        ModelResponse CrearCliente(ModelCliente cliente, string Conexion);
    }
}
