using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //MongoContext mc = new MongoContext();
            //var Categorias = new List<Categoria> {
            //    new Categoria { Descripcion = "Todo en camaras y accesorios de fotografia", Nombre = "Camaras" },
            //    new Categoria { Descripcion = "Hardware para PC", Nombre = "Hardware" },
            //    new Categoria { Descripcion = "Toda la gama de Celurales", Nombre = "Smartphones y Tablets" },
            //    new Categoria { Descripcion = "Toda la gama de TV", Nombre = "TV y Audio" },
            //    new Categoria { Descripcion = "Area de articulos para jugadores", Nombre = "Video Juegos y Consolas" },
            //    new Categoria { Descripcion = "Accesorios de diversos tipos", Nombre = "Accessorios" }
            //};
            //Categorias.ForEach(c => mc.Categorias.InsertOne(c));
            //Categoria categoria = (from c in mc.Categorias.AsQueryable<Categoria>() where c.Nombre == "Computadoras y Laptops" select c).First();
            //Producto pro = new Producto
            //{
            //    Categoria = categoria,
            //    Codigo = 454,
            //    Descripcion = "Computadora marca Lenovo Core i7, 16 gigas ram, 1 Tera store",
            //    Marca = "Lenovo",
            //    Imagen_ID = new ObjectId(),
            //    Nombre = "Lenovo Y780",
            //    Precio = 450000,
            //    Stock = new Stock { EnBodega = 100, EnVenta = 200},
            //    Valoracion = new Valoracion { Total_Valoraciones = 1, Valor = 5}
            //};
            //mc.Productos.InsertOne(pro);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}