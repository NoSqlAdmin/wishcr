using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Detalle
    {
        public Int32 Cantidad { get; set; }

        public Producto Producto { get; set; }
    
        public Double Subtotal { get => (Producto.Precio * Cantidad); }
    }
}