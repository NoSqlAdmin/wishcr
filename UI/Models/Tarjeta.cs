using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Tarjeta
    {
        public string NumeroTarjeta { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public int CodigoSeguridad { get; set; }
    }
}