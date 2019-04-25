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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            MongoContext mc = new MongoContext();
            var clientes = mc.Clientes.AsQueryable().ToList();
            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            MongoContext mc = new MongoContext();
            var cliente = mc.Clientes.AsQueryable().First(ad => ad.Cedula.Equals(id));
            return View(cliente);
        }

        public ActionResult Register(Cliente cliente)
        {
            try
            {
                MongoContext mc = new MongoContext();
                var clientes = mc.Clientes;
                cliente.Deseos = new List<Producto>();
                clientes.InsertOne(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        
        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            MongoContext mc = new MongoContext();
            var cliente = mc.Clientes.AsQueryable().First(ad => ad.Cedula.Equals(id));
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                MongoContext mc = new MongoContext();
                var filter = Builders<Cliente>.Filter.Eq("Usuario", cliente.Usuario);
                var update = Builders<Cliente>.Update
                    .Set(p => p.Nombre, cliente.Nombre)
                    .Set(p => p.Primer_Apellido, cliente.Primer_Apellido)
                    .Set(p => p.Segundo_Apellido, cliente.Segundo_Apellido)
                    .Set(p => p.Fecha_Nacimiento, cliente.Fecha_Nacimiento)
                    .Set(p => p.Direccion, cliente.Direccion)
                    .Set(p => p.Targetas_Credito, cliente.Targetas_Credito)
                    .Set(p => p.Correo, cliente.Correo);
                mc.Clientes.FindOneAndUpdate(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            MongoContext mc = new MongoContext();
            var client = mc.Clientes.DeleteOne(a => a.Cedula.Equals(id));
            return RedirectToAction("Index");
        }

        // GET: Cliente/Facturas
        public async Task<ActionResult> Facturas()
        {
            if (Store.Default.Cliente == null) return RedirectToAction("Index", "Home");
            MongoContext mc = new MongoContext();
            var cedula = Store.Default.Cliente.Cedula;
            var filter = Builders<Factura>.Filter.Eq(f => f.Cliente.Cedula, cedula);
            var facturas = await mc.Facturas.Find(filter).ToListAsync();
            return View(facturas);
        }

    }
}
