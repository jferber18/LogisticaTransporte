using Model.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IServiceCliente
    {
        ModelResponse ListarClientes(string Conexion, int IdCliente = 0);
        ModelResponse CrearCliente(ModelCliente cliente, string Conexion);
        ModelResponse ValidarCamposCliente(ModelCliente cliente);
    }
}
