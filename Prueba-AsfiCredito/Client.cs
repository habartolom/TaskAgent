using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Prueba_AsfiCredito
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public string UserName { get; set; }
    }
}
