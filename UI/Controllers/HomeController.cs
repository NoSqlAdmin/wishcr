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
            MongoContext mc = new MongoContext();
            var productos = mc.Productos.AsQueryable().ToList();
            ViewBag.Productos = productos;
            var nuevos = (from p in productos where (p.Fecha_Ingreso.Date - DateTime.Now.Date).Days < 25 select p).ToList();
            ViewBag.ProductosNuevos = nuevos;
            ViewBag.ProductosJuegos = (from p in nuevos where p.Categoria.Nombre.Equals("Video Juegos y Consolas") select p).OrderBy(p => p.Fecha_Ingreso).Take(16);
            ViewBag.ProductosComputadoras = (from p in nuevos where p.Categoria.Nombre.Equals("Computadoras y Laptops") select p).OrderBy(p => p.Fecha_Ingreso).Take(16);
            ViewBag.ProductosVideos = (from p in nuevos where p.Categoria.Nombre.Equals("TV y Audio") select p).OrderBy(p => p.Fecha_Ingreso).Take(16);
            ViewBag.ProductosValorados = productos.OrderBy(p => p.Valoracion.Valor).Take(16);
            ViewBag.Cliente = Store.Default.Cliente;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            MongoContext mc = new MongoContext();
            //ViewBag.Categorias = mc.Categorias.AsQueryable().ToList();
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

            //      Cliente cliente = new Cliente
            //{
            //    Cedula = "113960817",
            //    Contrasena = "contraseña",
            //    Correo = "david@gmail.com",
            //    Deseos = new List<Producto>(),
            //    Direccion = "La león 13",
            //    Fecha_Nacimiento = new DateTime(2000,5,13).Date,
            //    Nombre = "David",
            //    Primer_Apellido = "Campos",
            //    Segundo_Apellido = "Chavarría",
            //    Targetas_Credito = new List<Tarjeta>() { new Tarjeta {
            //        CodigoSeguridad = 4545,
            //        FechaExpiracion = new DateTime(2040,5,12),
            //        NumeroTarjeta = "66-4646-44-4455"
            //    }
            //    },
            //    Usuario = "davidcc"
            //};
            //mc.Clientes.InsertOne(cliente);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}