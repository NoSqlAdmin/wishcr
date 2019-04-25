using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using UI.Models;


namespace UI.Controllers
{
    public class ProductoController : Controller
    {


        // GET: Producto
        public ActionResult Index()
        {
            MongoContext mc = new MongoContext();
            var producto = mc.Productos;
            var productos = producto.AsQueryable();
            return View(productos);
        }

        // GET: Producto/Details/5
        public ActionResult Details(string id)
        {
            MongoContext mc = new MongoContext();
            var producto = mc.Productos.AsQueryable().First(a => a.Id.Equals(id));
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            var categorias = new List<SelectListItem>();
            MongoContext mc = new MongoContext();
            mc.Categorias.AsQueryable().ToList().ForEach(c =>
            {
                categorias.Add(new SelectListItem { Value = c.Id, Text = c.Nombre });
            });
            ViewBag.Categorias = categorias;
            Producto p = new Producto()
            {
                Valoracion = new Valoracion { Total_Valoraciones = 1, Valor = 1 },
                Stock = new Stock() { EnBodega = 0, EnVenta = 1},
                Imagen_ID = ObjectId.GenerateNewId()
            };
            return View(p);
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(string categoria,Producto p, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                if (file != null)
                {
                    MongoContext mc = new MongoContext();
                    string idImagen = Gridfs.Default.SaveImage(file.FileName, file.InputStream);
                    Categoria catego = mc.Categorias.AsQueryable<Categoria>().ToList().First(c => c.Id.Equals(categoria));
                    Producto producto = new Producto
                    {
                        Stock = new Stock { EnBodega = p.Stock.EnBodega, EnVenta = p.Stock.EnVenta },
                        Categoria = catego,
                        Codigo = p.Codigo,
                        Descripcion = p.Descripcion,
                        Fecha_Ingreso = DateTime.Now.Date,
                        Imagen = idImagen,
                        Marca = p.Marca,
                        Nombre = p.Nombre,
                        Precio = p.Precio,
                        Valoracion = new Valoracion { Total_Valoraciones = 1, Valor = p.Valoracion.Valor }
                    };
                    mc.Productos.InsertOne(producto);
                }
                else
                {
                    throw new FileNotFoundException();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                var categorias = new List<SelectListItem>();
                MongoContext mc = new MongoContext();
                mc.Categorias.AsQueryable().ToList().ForEach(c =>
                {
                    categorias.Add(new SelectListItem { Value = c.Id, Text = c.Nombre });
                });
                ViewBag.Categorias = categorias;
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(string id)
        {
            MongoContext mc = new MongoContext();
            var producto = mc.Productos.AsQueryable().First(a => a.Id.Equals(id));
            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, int codigo, string nombre, string descripcion, string marca, double precio, HttpPostedFileBase file)
        {
            try
            {
                MongoContext mc = new MongoContext();
                var filter = Builders<Producto>.Filter.Eq("_id", ObjectId.Parse(id));
                if (file != null)
                {
                    var imagen = Gridfs.Default.SaveImage(file.FileName, file.InputStream);
                    var update = Builders<Producto>.Update.Set(p => p.Nombre, nombre).Set(p => p.Descripcion, descripcion).Set(p => p.Marca, marca).Set(p => p.Precio, precio).Set(p => p.Imagen, imagen);
                    mc.Productos.FindOneAndUpdate(filter, update);
                }
                else
                {
                    var update = Builders<Producto>.Update.Set(p => p.Nombre, nombre).Set(p => p.Descripcion, descripcion).Set(p => p.Marca, marca).Set(p => p.Precio, precio);
                    mc.Productos.FindOneAndUpdate(filter, update);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(string id)
        {
            MongoContext mc = new MongoContext();
            var producto = mc.Productos.DeleteOne(a => a.Id.Equals(id));
            return RedirectToAction("Index");
        }

    }
}
