using Login.Database.Context;
using Login.Database.Entities;
using Microsoft.Extensions.Logging;

namespace Login.Repositories
{
	public class ClientRepository : IClientRepository
	{
		private readonly SqLiteDbContext _db;
		public ClientRepository(SqLiteDbContext db)
		{
			_db = db;
		}
		private async Task<Client> FindById(Guid id)
		{
			return await _db.Clients.FindAsync(id);
		}
		public async void Delete(Guid id)
		{
			Client client = await FindById(id);
			_db.Clients.Remove(client);
			_db.SaveChanges();
		}

		public IEnumerable<Client> GetAll()
		{
			return _db.Clients.AsEnumerable();
		}

		public Client GetByEmail(string email)
		{
			return _db.Clients.First(x => x.Email == email);
		}

		public Client GetByEmailAndPassword(string email, string password)
		{
			return _db.Clients.First(x => x.Email == email && x.Password == password);
		}

		public async Task Insert(Client client)
		{
			client.Id = Guid.NewGuid();
			await _db.Clients.AddAsync(client);
			await _db.SaveChangesAsync();
		}

		public async Task Update(Client client)
		{
			Client clientDb = await FindById(client.Id);
			_db.Entry(clientDb).CurrentValues.SetValues(client);
			await _db.SaveChangesAsync();
		}
	}
}
