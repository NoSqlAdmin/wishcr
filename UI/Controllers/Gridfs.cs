using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver.GridFS;
using static UI.Controllers.Gridfs;
using MongoDB.Bson;
using System.Web.Hosting;

namespace UI.Controllers
{
    public class Gridfs
    {
        
        private static Gridfs _default;

        public static Gridfs Default => _default ?? (_default = new Gridfs());

        private ObjectId _id;
        public string ID
        {
            get { return Convert.ToString(_id); }
            set { _id = ObjectId.Parse(value); }
        }

        public String GetImagePath(string id)
        {
            string fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/images"), id+".png");
            if (!File.Exists(fileName))
            {
                MongoContext mc = new MongoContext();
                var database = mc.MongoCliente.GetDatabase("imagen");
                var bucket = new GridFSBucket(database);
                ID = id;
                using (var fs = new FileStream(fileName, FileMode.Create))
                {
                    bucket.DownloadToStream(_id, fs);
                    fs.Close();
                }
            }
            return "~/images/" + id + ".png";
        }

        public String SaveImage(string fileName, Stream stream)
        {
            MongoContext mc = new MongoContext();
            var database = mc.MongoCliente.GetDatabase("imagen");
            var bucket = new GridFSBucket(database);
            using (var fs = stream)
            {
                var gridFsInfo = bucket.UploadFromStream(fileName, fs);
                _id = gridFsInfo;
                fs.Close();
            }
            return ID;
        }


        //public void Carga()
        //{
        //    MongoContext mc = new MongoContext();
        //    var database = mc.MongoCliente.GetDatabase("testimagen");
        //    var bucket = new GridFSBucket(database);
        //    var path = HostingEnvironment.ApplicationPhysicalPath;
        //    var fileName = path + "/images/logos_1.png";
        //    var newFileName = path + "/images/logos_descagado.png";
        //    using (var fs = new FileStream(fileName, FileMode.Open))
        //    {
        //        var gridFsInfo = bucket.UploadFromStream(fileName,fs);
        //        ObjectId oid = gridFsInfo;
        //        fs.Close();
        //        var file = new FileStream(newFileName, FileMode.Create);
        //        bucket.DownloadToStream(oid,file);
        //        file.Close();
        //    }
        //}
    }
}