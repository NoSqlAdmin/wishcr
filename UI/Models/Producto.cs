using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Producto
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public int Categoria { get; set; }

        public float Precio { get; set; }

        public int Cantidad { get; set; }

        public string Imagen { get; set; }

        public Proveedor Proveedor { get; set; }
    }
}