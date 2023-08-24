using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Clases
{
    public class ModelBodegaPuerto
    {
        public int IdCliente { get; set; }
        public int IdTipoLogistica { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Activo { get; set; }
    }
}
