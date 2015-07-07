using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoSample
{
    public class MongoRep
    {
        public MongoDatabase GetDB()
        {
            MongoServerAddress address = new MongoServerAddress("127.0.0.1", 27017);

            MongoServerSettings settings = new MongoServerSettings();

            settings.Server = address;

            MongoServer server = new MongoServer(settings);

            MongoDatabase myDB = server.GetDatabase("MyDB");

            return myDB;
        }

        public List<AdminData> GetCollection()
        {
            try
            {
                List<AdminData> adminDataList = new List<AdminData>();

                MongoDatabase myDB = GetDB();

                MongoCollection<AdminData> adminDataTable = myDB.GetCollection<AdminData>("AdminData");

                MongoCursor<BsonDocument> cursor = adminDataTable.FindAllAs<BsonDocument>();

                foreach (var item in cursor)
                {
                    AdminData admnData = new AdminData();

                    admnData._id = (ObjectId)item["_id"];

                    admnData.Address = item["Address"].ToString();

                    admnData.Name = item["Name"].ToString();

                    admnData.Age = Convert.ToInt32(item["Age"].ToString());

                    admnData.SlNo = Convert.ToInt32(item["SlNo"].ToString());

                    adminDataList.Add(admnData);
                }

               // grdcAdminData.ItemsSource = adminDataList;

                return adminDataList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string InsertDocument(AdminData adminData)
        {
            try
            {

                MongoDatabase myDB = GetDB();

                MongoCollection<AdminData> adminDataTable = myDB.GetCollection<AdminData>("AdminData");

                adminDataTable.Insert(adminData);

                return "Succcess";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string UpdateDocument(AdminData adminData)
        {
            try
            {
                MongoDatabase myDB = GetDB();

                MongoCollection<AdminData> adminDataTable = myDB.GetCollection<AdminData>("AdminData");

                QueryDocument queryDoc = new QueryDocument("_id", adminData._id);

                IMongoQuery query = queryDoc;

                //    IMongoUpdate update = new UpdateDocument("Address","Hyd");

                //  IMongoUpdate update = new UpdateDocument().Set("Address", "Hyd") as UpdateDocument;

                //   IMongoUpdate update = new UpdateDocument().Set(queryDoc.IndexOfName("Address"), "Hyd") as UpdateDocument;

                var updateDoc = Update.Set("Address", adminData.Address).Set("Age",adminData.Age.ToString()).Set("Name",adminData.Name).Set("SlNo",adminData.SlNo.ToString());

                IMongoUpdate update = updateDoc;

                WriteConcernResult updateResult = adminDataTable.Update(query, update);

                return "Succcess";
                //  adminDataTable.Update()

                // GetCollection();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string DeleteDocument(ObjectId id)
        {
            try
            {
                MongoDatabase myDB = GetDB();

                MongoCollection<AdminData> adminDataTable = myDB.GetCollection<AdminData>("AdminData");

                QueryDocument queryDoc = new QueryDocument("_id", id);

                IMongoQuery query = queryDoc;

                WriteConcernResult deletionResult = adminDataTable.Remove(query);

                //   GetCollection();

                return "Succcess";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
}
