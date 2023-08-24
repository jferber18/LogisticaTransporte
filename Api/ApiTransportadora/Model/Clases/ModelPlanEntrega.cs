using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Clases
{
    public class ModelPlanEntrega
    {
        public int IdProducto { get; set; }
        public int IdTipoLogistica { get; set; }
        public int CantidadProducto { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaEntrega { get; set; }
        public int IdBodega { get; set; }
        public string NumeroGuia { get; set; } = "";
        public string PlacaVehiculo { get; set; } = "";
        public string NumeroFlota { get; set; } = "";
    }
}
