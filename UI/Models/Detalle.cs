using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using MongoDB.Bson.Serialization.Attributes;

namespace UI.Models
{
    public class Detalle
    {
        [BsonConstructor]
        public Detalle(int cantidad, Producto producto, double subtotal)
        {
            Cantidad = cantidad;
            Producto = producto ?? throw new ArgumentNullException(nameof(producto));
            Subtotal = subtotal;
        }

        [BsonConstructor]
        public Detalle()
        {

        }

        [Required]
        public Int32 Cantidad { get; set; }
        [Required]
        public Producto Producto { get; set; }

        private Double _subtotal;
        public Double Subtotal { get {return (Producto.Precio * Cantidad); } set { _subtotal = value;} }
}
}