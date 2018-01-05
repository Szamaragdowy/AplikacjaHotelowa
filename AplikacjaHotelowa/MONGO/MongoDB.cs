using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Xml.Linq;

namespace AplikacjaHotelowa.MONGO
{
    static class MongoDB
    {
        static public void Add_action(String login,String akcja,DateTime data)
        {
            var connectionString = "mongodb://localhost";
            var mongoClient = new MongoClient(connectionString);

            MongoServer mongoServer = mongoClient.GetServer();
            var database =  mongoServer.GetDatabase("new_db");
            var collection = database.GetCollection<BsonDocument>("Akcje");

            var document = new BsonDocument
            {
                {"Login",login},
                {"Działanie",akcja},
                {"Data",data}
            };

            collection.Insert(document);
            mongoServer.Disconnect();
        }

    }
}
