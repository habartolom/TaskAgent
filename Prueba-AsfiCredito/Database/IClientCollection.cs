using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_AsfiCredito.Database
{
    interface IClientCollection
    {
        Task InsertClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(String id);
        Task<List<Client>> getAllClientes();
        Task<Client> getClienteByEmailAndPassword(string email, string password);
        Task<Client> getClienteByEmail(string email);
    }
}
