using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Clases
{
    public class ModelCliente
    {
        public string NombreCliente { get; set; }
        public int IdTipoDoc { get; set; }
        public int Telefono { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public List<Producto> Productos { get; set; }
    }

    public class Producto
    {
        public string NombreProducto { get; set; }
        public int TipoLogistica { get; set; }
        public int Activo { get; set; }
    }
}
