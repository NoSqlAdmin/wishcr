﻿using MongoDB.Driver;
using System.Collections.Generic;
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
            //System.Web.HttpContext.Current.Session["userid"] = "113960817";
            //return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> LoginAsync(string Usuario, string Contrasena)
        {
            if (Usuario != "" && Contrasena != "")
            {
                MongoContext mc = new MongoContext();
                var cliente = await mc.Clientes.Find(c => c.Usuario.Equals(Usuario)).FirstOrDefaultAsync();
                if (cliente != null)
                {
                    if (cliente.Contrasena.Equals(Contrasena))
                    {
                        System.Web.HttpContext.Current.Session["userid"] = cliente.Cedula;
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("Contrasena", "La contraseña o el usuario no coinciden");

                        return View("Login");

                    }
                }
                else
                {
                    ModelState.AddModelError("Usuario", "Usuario no encontrado");

                    return View("Login");


                }

            }
            else
            {

                return RedirectToAction("Login", "Auth");
            }
        }

        [HttpGet]
        // GET: Auth
        public ActionResult LoginAdmin()
        {
            //System.Web.HttpContext.Current.Session["userid"] = "113960817";
            //return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> LoginAdminAsync(string Usuario, string Contrasena)
        {
            if (Usuario != "" && Contrasena != "")
            {

                MongoContext mc = new MongoContext();
                var admins = mc.Administradores.AsQueryable().ToList();
                var admi = await mc.Administradores.Find(c => c.Usuario.Equals(Usuario)).FirstOrDefaultAsync();
                if (admi != null)
                {
                    if (admi.Contrasena.Equals(Contrasena))
                    {
                        System.Web.HttpContext.Current.Session["adminid"] = admi.Cedula;
                        return RedirectToAction("IndexAdmin","Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Contrasena", "La contraseña o el usuario no coinciden");
                        return View("LoginAdmin");
                    }
                }
                else
                {
                    ModelState.AddModelError("Usuario", "Usuario no encontrado");
                    return View("LoginAdmin");
                }
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Auth");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Cliente cliente)

        {
            try
            {
                MongoContext mc = new MongoContext();
                var clientes = mc.Clientes;
                cliente.Deseos = new List<Producto>();
                clientes.InsertOne(cliente);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult SessionDown()
        {
            System.Web.HttpContext.Current.Session["userid"] = null;
            System.Web.HttpContext.Current.Session["adminid"] = null;
            Store.Default.Carrito.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}