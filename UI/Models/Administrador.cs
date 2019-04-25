using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Administrador
    {
        [BsonId]
        [Required]
        public String Cedula { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        [DisplayName("Primer Apellido")]
        public String Primer_Apellido { get; set; }
        [Required]
        [DisplayName("Segundo Apellido")]
        public String Segundo_Apellido { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required]
        public String Usuario { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public String Contrasena { get; set; }
        [DisplayName("Dirección")]
        public String Direccion { get; set; }
        [Required]
        [DataType(dataType: DataType.EmailAddress)]
        [DisplayName("Email")]
        public String Correo { get; set; }
    }
}