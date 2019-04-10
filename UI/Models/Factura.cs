using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace UI.Models
{
    public class Factura
    {
        public Factura(long numero_Factura, IEnumerable<Detalle> detalles, Cliente cliente)
        {
            Numero_Factura = numero_Factura;
            Detalles = detalles ?? throw new ArgumentNullException(nameof(detalles));
            if (detalles.Count() < 1) throw new ArgumentNullException(nameof(detalles));
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public String Empresa { get => "WishCR"; }
        public String Cedula_Juridica { get => "3-101-013528"; }
        [Required]
        public long Numero_Factura { get; set; }
        public DateTime Fecha { get => DateTime.Now; }
        [Required]
        public Cliente Cliente { get; set; }
        [Required]
        public IEnumerable<Detalle> Detalles { get; set; }
        public Double Subtotal { get => Detalles.Sum(d => d.Subtotal); }
        public Int32 IVA { get => 13; }
        public Double Total { get => (((Subtotal / 100) * IVA) + Subtotal); }
        
    }
}
