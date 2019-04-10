using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Stock
    {
        public int EnVenta { get; set; }

        public int EnBodega { get; set; }
    }
}