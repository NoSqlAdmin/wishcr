using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Carrito
    {
        public IEnumerable<Detalle> Productos { get; set; }
    }
}