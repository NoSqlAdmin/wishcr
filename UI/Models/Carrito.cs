﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Carrito
    {
        public IEnumerable<Detalle> Productos { get; set; }
    }
}