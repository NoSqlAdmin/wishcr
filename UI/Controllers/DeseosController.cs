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
        public ActionResult Index()
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
        public  JsonResult Create(string name/*string producto, string cedula = "ninguno"*/)
        {
            string cedula = "ss";
            if (cedula.Equals(name)) return Json("Error",JsonRequestBehavior.AllowGet);
            using (MongoContext mc = new MongoContext())
            {
                //var filter = Builders<Cliente>.Filter.Eq("_id", cedula);
                //var cliente = await mc.Clientes.Find(filter).FirstAsync();
                //var deseo = await mc.Productos.Find(Builders<Producto>.Filter.Eq("_id",producto)).FirstAsync();
                //cliente.Deseos.ToList().Add(deseo);
                //var update = Builders<Cliente>.Update.Set("Deseos", cliente.Deseos);
                //var result = await mc.Clientes.UpdateOneAsync(filter, update);
                //reu
            }
            return Json("Error", JsonRequestBehavior.AllowGet);
        }
        

        // GET: Deseos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deseos/Edit/5
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

        // GET: Deseos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deseos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
