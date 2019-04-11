using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class DeseosController : Controller
    {
        // GET: Deseos
        public ActionResult Index(int id)
        {
            return View();
        }

        // GET: Deseos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        // GET: Deseos/Create
        public async Task<JsonResult> Create(string producto, string cedula)
        {
            if (cedula.Equals("ninguno")) return Json("Error", JsonRequestBehavior.AllowGet);
            MongoContext mc = new MongoContext();
            var filter = Builders<Cliente>.Filter.Eq("_id", cedula);
            var cliente = await mc.Clientes.Find(filter).FirstAsync();
            var deseo = await mc.Productos.Find(Builders<Producto>.Filter.Eq("_id", ObjectId.Parse(producto))).FirstAsync();
            var deseos = cliente.Deseos.ToList();
            var resultado = "Success++";
            if (deseos.Exists(d => d.Id.Equals(deseo.Id)))
            {
                deseos.Remove(deseos.First(d => d.Id.Equals(deseo.Id)));
                resultado = "Success--";
            } else
                deseos.Add(deseo);
            var update = Builders<Cliente>.Update.Set(c => c.Deseos, deseos);
            var result = await mc.Clientes.FindOneAndUpdateAsync(filter, update);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        
    }
}
