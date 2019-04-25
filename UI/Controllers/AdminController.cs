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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            MongoContext mc = new MongoContext();
            var admin = mc.Administradores;
            var adminis = admin.AsQueryable();
            return View(adminis);

        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            MongoContext mc = new MongoContext();
            var administrador = mc.Administradores.AsQueryable().First(ad => ad.Cedula.Equals(id));
            return View(administrador);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {

            var administradores = new List<SelectListItem>();
            MongoContext mc = new MongoContext();
            mc.Administradores.AsQueryable().ToList().ForEach(c =>
            {
                administradores.Add(new SelectListItem { Value = c.Cedula, Text = c.Nombre });
            });
            ViewBag.Administradores = administradores;
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(String cedula, String nombre, String primer_Apellido, String segundo_Apellido, DateTime fecha_Nacimiento, String usuario, String contrasena, String direccion, String correo)
        {
            try
            {
                // TODO: Add insert logic here

                MongoContext mc = new MongoContext();
                Administrador administrador = new Administrador
                {
                    Cedula = cedula,
                    Nombre = nombre,
                    Primer_Apellido = primer_Apellido,
                    Segundo_Apellido = segundo_Apellido,
                    Fecha_Nacimiento = fecha_Nacimiento,
                    Usuario = usuario,
                    Contrasena = contrasena,
                    Direccion = direccion,
                    Correo = correo,
                };
                mc.Administradores.InsertOne(administrador);
                return RedirectToAction("IndexAdmin", "Home");
            }

            catch
            {
                var admin = new List<SelectListItem>();
                MongoContext mc = new MongoContext();
                mc.Administradores.AsQueryable().ToList().ForEach(c =>
                {
                    admin.Add(new SelectListItem { Value = c.Usuario, Text = c.Nombre });
                });
                ViewBag.Administradores = admin;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            MongoContext mc = new MongoContext();
            var administrador = mc.Administradores.AsQueryable().First(ad => ad.Cedula.Equals(id));
            return View(administrador);
        }


        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(string cedula, String nombre, String primer_Apellido, String segundo_Apellido, DateTime fecha_Nacimiento, String usuario, String contrasena, String direccion, String correo)
        {
            try
            {
                MongoContext mc = new MongoContext();
                var filter = Builders<Administrador>.Filter.Eq("Usuario", usuario);
                var update = Builders<Administrador>.Update
                    .Set(p => p.Nombre, nombre)
                    .Set(p => p.Primer_Apellido, primer_Apellido)
                    .Set(p => p.Segundo_Apellido, segundo_Apellido)
                    .Set(p => p.Fecha_Nacimiento, fecha_Nacimiento)
                    .Set(p => p.Direccion, direccion)
                    .Set(p => p.Correo, correo);
                mc.Administradores.FindOneAndUpdate(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5

        public ActionResult Delete(String id)
        {
            MongoContext mc = new MongoContext();

            var admin = mc.Administradores.DeleteOne(a => a.Cedula.Equals(id));

            return RedirectToAction("Index");

        }


    }
}
