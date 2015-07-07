using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoSample
{
    public class AdminData
    {
        public ObjectId _id { get; set; }

        public string Name { get; set; }

        public int SlNo { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public AdminData()
        {

        }

        public AdminData(ObjectId _id, string name, int slno, int age, string address)
        {
            this._id = _id;
            this.Name = name;
            this.SlNo = slno;
            this.Age = age;
            this.Address = address;
        }
    }

}
