using Login.Database.Entities;

namespace Login.Repositories
{
	public interface IClientRepository
	{
		void Delete(string id);
		IEnumerable<Client> GetAll();
		Client GetByEmail(string email);
		Client GetByEmailAndPassword(string email, string password);
		Task Insert(Client client);
		Task Update(Client client);
	}
}
