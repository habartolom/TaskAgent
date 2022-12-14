using Login.Database.Entities;
using Login.DTO;

namespace Login.Services
{
	public interface IClientService
	{
		void Delete(Guid id);
		IEnumerable<Client> GetAll();
		Client GetByEmail(string email);
		Client GetByEmailAndPassword(string email, string password);
		Task Insert(DTClient client);
		Task Update(DTClient client, Guid id);
	}
}
