using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MongoDB.Driver.GridFS;
using static UI.Controllers.Grifs;
using MongoDB.Bson;

namespace UI.Controllers
{
    public class Grifs
    {
        public void carga()
        {
            MongoClient mongoClient = new MongoClient();
            var database = mongoClient.GetDatabase("tesdb");
            var bucket = new GridFSBucket(database);
            var fileName = "D:\\Untitled.png";
            var newFileName = "D:\\new_Untitled.png";
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var gridFsInfo = bucket.UploadFromStream(fileName,fs);
                ObjectId oid = gridFsInfo;
                var file = new MemoryStream();
                bucket.DownloadToStream(oid,file);
                using (var stream = file)
                {
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    using (var newFs = new FileStream(newFileName, FileMode.Create))
                    {
                        newFs.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        private ObjectId _id;
        public string Id
        {
            get { return Convert.ToString(_id); }
            set { _id = ObjectId.Parse(value); }
        }

    }
}