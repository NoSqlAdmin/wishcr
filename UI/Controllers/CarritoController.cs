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

        // GET: Carrito/Comprar
        public ActionResult Comprar()
        {
            Random rnd = new Random();
            var valor = rnd.Next(1000,10000);
            Factura factura = new Factura(Convert.ToInt64("1120000204"+valor),Store.Default.Carrito,Store.Default.Cliente);
            Store.Default.FacturaTemp = factura;
            return View(factura);
        }

        [HttpPost]
        // POST: Carrito/Facturar
        public ActionResult Facturar()
        {
            MongoContext mc = new MongoContext();
            Factura factura = Store.Default.FacturaTemp;
            factura.Detalles.ToList().ForEach(f => {
                var filter = Builders<Producto>.Filter.Eq("_id",ObjectId.Parse(f.Producto.Id));
                var stock = f.Producto.Stock;
                stock.EnVenta -= f.Cantidad;
                var update = Builders<Producto>.Update.Set(p => p.Stock, stock);
                mc.Productos.FindOneAndUpdate(filter, update);
            });
            mc.Facturas.InsertOne(factura);
            Store.Default.FacturaTemp = null;
            Store.Default.Carrito = new List<Detalle>();
            return RedirectToAction("Index","Home");
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
        
        // GET: Carrito/Delete/5
        public ActionResult Delete(int id)
        {
            Store.Default.Carrito.RemoveAt(id);
            return View("Index", Store.Default.Carrito);
        }
        
    }
}
