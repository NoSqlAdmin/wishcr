using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public Int32 Codigo { get; set; }

        public String Nombre { get; set; }

        public String Descripcion { get; set; }

        public Double Precio { get; set; }

        public String Imagen { get; set; }

        public Categoria Categoria { get; set; }
        public Stock Stock { get; set; }

        public Valoracion Valoracion { get; set; }

        [BsonIgnore]
        public ObjectId Imagen_ID { get { return ObjectId.Parse(Imagen); } set { Imagen = value.ToString(); } }
    }
}