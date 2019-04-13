using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        // GET: Auth
        public ActionResult Login()
        {
            System.Web.HttpContext.Current.Session["userid"] = "113960817";
            return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Login(string password, string user)
        {
            System.Web.HttpContext.Current.Session["userid"] = "113960817";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Cliente cliente)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SessionDown()
        {
            System.Web.HttpContext.Current.Session["userid"] = null;
            Store.Default.Carrito.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}