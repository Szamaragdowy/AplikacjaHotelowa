using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaHotelowa.MONGO
{
    class Akcja
    {
        public ObjectId _id  { get; set; }
        public String Login { get; set; }
        public  String Działanie { get; set; }
        public DateTime Data { get; set; }

    }
}
