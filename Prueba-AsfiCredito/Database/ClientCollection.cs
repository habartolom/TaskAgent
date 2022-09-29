using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using NLog;

namespace Prueba_AsfiCredito.Database
{
    public class ClientCollection : IClientCollection
    {

        internal MongoRepository mongo = new MongoRepository();
        private IMongoCollection<Client> collection;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ClientCollection()
        {
            collection = mongo.database.GetCollection<Client>("Clientes");
        }

        public async Task DeleteClient(String id)
        {
            var filter = Builders<Client>.Filter.Eq(s => s.Id, id);
            try {
                await collection.DeleteOneAsync(filter);
                logger.Info("Info: The client has been deleted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The client could not be deleted, Error: " + e);
            }
            
        }

        public async Task<List<Client>> getAllClientes()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
            try
            {
                logger.Info("Info: The clients have been obtained successfully");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The clients could not be obtained successfully, Error: " + e);
            }
        }

        public async Task<Client> getClienteByEmailAndPassword(string email, string password)
        {
            return await collection.FindAsync
                (new BsonDocument { { "Email", email }, { "Password", password } }).Result.FirstAsync();
            try
            {
                logger.Info("Info: The client login was successful");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The client login was unsuccessful, Error: " + e);
            }
        }

        public async Task<Client> getClienteByEmail(string email)
        {
            return await collection.FindAsync
                (new BsonDocument { { "Email", email } }).Result.FirstAsync();
            try
            {
                logger.Info("Info: Client password reset was successful");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: Client password reset was unsuccessful, Error: " + e);
            }
        }

        public async Task InsertClient(Client client)
        {
            try
            {
                await collection.InsertOneAsync(client);
                logger.Info("Info: The client was inserted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The client was not inserted, Error: " + e);
            }
        }

        public async Task UpdateClient(Client client)
        {
            var filter = Builders<Client>.Filter.Eq(s => s.Id, client.Id);
            try
            {
                await collection.ReplaceOneAsync(filter, client);
                logger.Info("Info: The client was updated");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The client was not updated, Error: " + e);
            }
            
        }
    }
}
