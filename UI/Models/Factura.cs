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
            Fecha = DateTime.Now;
        }

        [BsonConstructor]
        public Factura()
        {

        }

        [BsonConstructor]
        public Factura(string id, string empresa, string cedula_Juridica, long numero_Factura, DateTime fecha, Cliente cliente, IEnumerable<Detalle> detalles, double subtotal, int iVA, double total)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Empresa = empresa ?? throw new ArgumentNullException(nameof(empresa));
            Cedula_Juridica = cedula_Juridica ?? throw new ArgumentNullException(nameof(cedula_Juridica));
            Numero_Factura = numero_Factura;
            Fecha = fecha;
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            Detalles = detalles ?? throw new ArgumentNullException(nameof(detalles));
            Subtotal = subtotal;
            IVA = iVA;
            Total = total;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        private String _empresa;
        public String Empresa { get { return "WishCR"; } set { _empresa = value; } }
        private String _cedula_juridica;
        [DisplayName("Cedula Juridica")]
        public String Cedula_Juridica { get { return "3-101-013528"; } set { _cedula_juridica = value; } }
        [Required]
        [DisplayName("Numero de Factura")]
        public long Numero_Factura { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
        [Required]
        public IEnumerable<Detalle> Detalles { get; set; }
        private Double _subtotal;
        public Double Subtotal { get { return Detalles.Sum(d => d.Subtotal); }  set { _subtotal = value; } }
        private Int32 _iva;
        public Int32 IVA { get { return 13; } set { _iva = value; } }
        private Double _total;
        public Double Total { get { return (((Subtotal / 100) * IVA) + Subtotal); }  set { _total = value; } }

    }
}
