using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using UI.Models;

namespace UI.Controllers
{
    public class MongoContext
    {
        private readonly MongoClient mongoCliente;

        public MongoClient MongoCliente => mongoCliente;

        private readonly IMongoDatabase db;

        public IMongoDatabase DB => db;

        public IMongoCollection<Producto> Productos => DB.GetCollection<Producto>("Producto");
        public IMongoCollection<Cliente> Clientes => DB.GetCollection<Cliente>("Cliente");
        public IMongoCollection<Categoria> Categorias => DB.GetCollection<Categoria>("Categoria");
        public IMongoCollection<Factura> Facturas => DB.GetCollection<Factura>("Factura");
        public IMongoCollection<Administrador> Administradores => DB.GetCollection<Administrador>("Administrador");

        public MongoContext()        //constructor   
        {
            // Leyendo credenciales desde app.config file   
            var MongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"]; //Wishdb  
            var MongoconnectionString = ConfigurationManager.AppSettings["MongoconnectionString"]; //mongodb://localhost:27017/Wishdb 
            // usando connection string
            mongoCliente = new MongoClient(MongoconnectionString);
            // Obteniendo la base de datos
            db = mongoCliente.GetDatabase(MongoDatabaseName);
        }

        public IMongoCollection<Cliente> LosClientes
        {
            get
            {
                return (db.GetCollection<Cliente>("Cliente"));
            }
            set
            {
            }
        }

    }
}