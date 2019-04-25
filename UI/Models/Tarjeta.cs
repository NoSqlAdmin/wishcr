using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Tarjeta
    {
        [Required]
        [DisplayName("Numero de Tarjeta")]
        public String NumeroTarjeta { get; set; }
        [Required]
        [DisplayName("Fecha de Expiracion")]
        public DateTime FechaExpiracion { get; set; }
        [Required]
        [DisplayName("Codigo de Seguridad")]
        public Int32 CodigoSeguridad { get; set; }
    }
}