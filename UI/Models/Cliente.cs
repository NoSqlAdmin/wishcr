using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Cliente
    {
        [BsonId]
        [Required]
        [DisplayName("Cedula")]
        public String Cedula { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public String Nombre { get; set; }
        [Required]
        [DisplayName("Primer Apellido")]
        public String Primer_Apellido { get; set; }
        [Required]
        [DisplayName("Segundo Apellido")]
        public String Segundo_Apellido { get; set; }
        [Required]
        [BsonDateTimeOptions(DateOnly = true)]
        [DisplayName("Fecha de Nacimiento")]
        [DataType(dataType: DataType.Date)]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required]
        [DisplayName("Usuario")]
        public String Usuario { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public String Contrasena { get; set; }
        [Required]
        [DisplayName("Dirección")]
        public String Direccion { get; set; }
        [Required]
        [DataType(dataType: DataType.EmailAddress)]
        [DisplayName("Email")]
        public String Correo { get; set; }
        [Required]
        [DisplayName("Targeta de Credito")]
        public String Targetas_Credito { get; set; }

        public IEnumerable<Producto> Deseos { get; set; }

        public static implicit operator Cliente(List<Cliente> v)
        {
            throw new NotImplementedException();
        }
    }
}