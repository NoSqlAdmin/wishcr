using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
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


       

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(String cedula, String nombre, String primer_Apellido, String segundo_Apellido, DateTime fecha_Nacimiento, String usuario, String contrasena, String direccion, String correo)
        {
            try
            {
                MongoContext mc = new MongoContext();
                var voll = mc.DB.GetCollection<Administrador>("Administrador");

                var update1 = MongoDB.Driver.Builders<Administrador>.Update.Set(s => s.Cedula, cedula);
                var update2= MongoDB.Driver.Builders<Administrador>.Update.Set(s => s.Nombre, nombre);
                var update3 = MongoDB.Driver.Builders<Administrador>.Update.Set(s => s.Primer_Apellido, primer_Apellido);
                var update4 = MongoDB.Driver.Builders<Administrador>.Update.Set(s => s.Segundo_Apellido, segundo_Apellido);
                var update5 = MongoDB.Driver.Builders<Administrador>.Update.Set(s => s.Fecha_Nacimiento, fecha_Nacimiento);
                var update6 = MongoDB.Driver.Builders<Administrador>.Update.Set(s => s.Usuario, usuario);
                var update7 = MongoDB.Driver.Builders<Administrador>.Update.Set(s => s.Contrasena, contrasena);
                var update8 = MongoDB.Driver.Builders<Administrador>.Update.Set(s => s.Direccion, direccion);
                var update9 = MongoDB.Driver.Builders<Administrador>.Update.Set(s => s.Correo, correo);

               
                 voll.FindOneAndUpdate(s => s.Cedula == cedula,update1);
                mc.Administradores.FindOneAndUpdate(s => s.Cedula == cedula,update1 );
                mc.Administradores.FindOneAndUpdate(s => s.Nombre == nombre, update2);
                mc.Administradores.FindOneAndUpdate(s => s.Primer_Apellido == primer_Apellido, update3);
                mc.Administradores.FindOneAndUpdate(s => s.Segundo_Apellido == segundo_Apellido, update4);
                mc.Administradores.FindOneAndUpdate(s => s.Fecha_Nacimiento == fecha_Nacimiento, update5);
                mc.Administradores.FindOneAndUpdate(s => s.Usuario == usuario, update6);
                mc.Administradores.FindOneAndUpdate(s => s.Contrasena == contrasena, update7);
                mc.Administradores.FindOneAndUpdate(s => s.Direccion == direccion, update8);
                mc.Administradores.FindOneAndUpdate(s => s.Correo == correo, update9);


                return RedirectToAction("Index");
            }
            catch
            {
               
                return View();
            }
        }

        // GET: Admin/Delete/5
       
        public ActionResult Delete(String nombre )
        {
            MongoContext mc = new MongoContext();

            var admin = mc.Administradores.DeleteOne(a => a.Nombre == nombre);

            return RedirectToAction("Index");

        }
       

    }
}
