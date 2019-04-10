using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        [Required]
        public Int32 Codigo { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        [DisplayName("Descripción")]
        public String Descripcion { get; set; }
        [Required]
        public String Marca { get; set; }
        [Required]
        public Double Precio { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime Fecha_Ingreso => DateTime.Now.Date;
        [Required]
        public String Imagen { get; set; }
        [Required]
        public Categoria Categoria { get; set; }
        public Stock Stock { get; set; }
        public Valoracion Valoracion { get; set; }

        [BsonIgnore]
        public ObjectId Imagen_ID { get { return ObjectId.Parse(Imagen); } set { Imagen = value.ToString(); } }
    }
}