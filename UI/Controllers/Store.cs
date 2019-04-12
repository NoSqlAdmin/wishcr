using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.Models;

namespace UI.Controllers
{
    public class Store
    {
        
        private static Store _default;

        private Store()
        {
            Carrito = new List<Detalle>();
        }

        public static Store Default => _default ?? (_default = new Store());

        public Cliente Cliente
        {
            get
            {
                var user = HttpContext.Current.Session["userid"];
                if (user != null)
                {
                    MongoContext mc = new MongoContext();
                    return mc.Clientes.Find(c => c.Cedula.Equals(user.ToString())).First();
                }
                else
                    return null;
            }
        }

        public List<Detalle> Carrito { get; set; }
    }
}