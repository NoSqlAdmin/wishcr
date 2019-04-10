using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Cliente
    {
        [BsonId]
        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Segundo_Apellido { get; set; }

        public string Primer_Apellido { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public string Direccion { get; set; }

        public string Correo { get; set; }

        public IEnumerable<Tarjeta> Targetas_Credito { get; set; }

        public IEnumerable<Producto> Deseos { get; set; }
    }
}