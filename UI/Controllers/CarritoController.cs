using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            return View(Store.Default.Carrito);
        }

        // GET: Carrito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Carrito/Create
        [HttpPost]
        public async Task<JsonResult> Create(string producto_id)
        {
            if (producto_id.Equals("ninguno")) return Json("Error", JsonRequestBehavior.AllowGet);
            String result = "";
            if (Store.Default.Carrito.Exists(d => d.Producto.Id.Equals(producto_id)))
            {
                Store.Default.Carrito.Find(d => d.Producto.Id.Equals(producto_id)).Cantidad++;
                var total = Store.Default.Carrito.Sum(d => d.Subtotal);
                result = "{ \"Estado\" : \"Success\", \"Total\" : \"" + total + "\" }";
            }
            else
            {
                MongoContext mc = new MongoContext();
                var producto = await mc.Productos.Find(Builders<Producto>.Filter.Eq("_id", ObjectId.Parse(producto_id))).FirstAsync();
                Store.Default.Carrito.Add(new Detalle
                {
                    Cantidad = 1,
                    Producto = producto
                });
                var total = Store.Default.Carrito.Sum(d => d.Subtotal);
                result = "{ \"Estado\" : \"Success++\", \"Total\" : \""+total+"\" }"; 
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Carrito/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carrito/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrito/Delete/5
        public ActionResult Delete(int id)
        {
            Store.Default.Carrito.RemoveAt(id);
            return View("Index", Store.Default.Carrito);
        }
        
    }
}
