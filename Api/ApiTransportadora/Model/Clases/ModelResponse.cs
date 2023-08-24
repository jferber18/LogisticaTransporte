using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Clases
{
    public class ModelResponse
    {
        public string mensaje { get; set; }
        public bool Estado { get; set; }
        public string excepcion { get; set; }
        public object response { get; set; }
    }
}
