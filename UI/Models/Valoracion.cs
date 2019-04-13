using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Valoracion
    {
        [Required]
        public long Total_Valoraciones { get; set; }
        [Required]
        public Int32 Valor { get; set; }

    }
}