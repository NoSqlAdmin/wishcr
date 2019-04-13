using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Stock
    {
        [Required]
        [DisplayName("En venta")]
        public Int32 EnVenta { get; set; }
        [Required]
        [DisplayName("En bodega")]
        public Int32 EnBodega { get; set; }
    }
}