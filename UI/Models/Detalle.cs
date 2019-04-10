using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Detalle
    {
        [Required]
        public Int32 Cantidad { get; set; }
        [Required]
        public Producto Producto { get; set; }

        public Double Subtotal => (Producto.Precio * Cantidad);
    }
}