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
    public class ArticulosController : Controller
    {
        // GET: Articulos
        public async Task<ActionResult> Index()
        {
            MongoContext mc = new MongoContext();
            var productos = await mc.Productos.Find(p => true).ToListAsync();
            ViewBag.Categorias = await mc.Categorias.Find(c => true).ToListAsync();
            ViewBag.Cliente = Store.Default.Cliente;
            return View(productos);
        }

        // GET: Articulos/Details/5
        public async Task<ActionResult> Details(string id)
        {
            MongoContext mc = new MongoContext();
            ViewBag.Categoria = await mc.Categorias.Find(c => c.Id.Equals(id)).FirstAsync();
            var productos = await mc.Productos.Find(p => p.Categoria.Id.Equals(id)).ToListAsync();
            ViewBag.Cliente = Store.Default.Cliente;
            return View(productos);
        }
        
    }
}
