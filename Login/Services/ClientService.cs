using Login.Database.Entities;
using Login.DTO;
using Login.Repositories;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Login.Services
{
	public class ClientService : IClientService
	{
		private readonly IClientRepository _clientRepository;

		public ClientService(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}

		public void Delete(Guid id)
		{
			_clientRepository.Delete(id);
		}

		public IEnumerable<Client> GetAll()
		{
			return _clientRepository.GetAll();
		}

		public Client GetByEmail(string email)
		{
			return _clientRepository.GetByEmail(email);
		}

		public Client GetByEmailAndPassword(string email, string password)
		{
			return _clientRepository.GetByEmailAndPassword(email, password);
		}

		public async Task Insert(DTClient dtClient)
		{
			string jsonDtClient =  JsonConvert.SerializeObject(dtClient);
			Client client = JsonConvert.DeserializeObject<Client>(jsonDtClient);
			
			await _clientRepository.Insert(client);
		}

		public async Task Update(DTClient dtClient, Guid id)
		{
			string jsonDtClient = JsonConvert.SerializeObject(dtClient);
			Client client = JsonConvert.DeserializeObject<Client>(jsonDtClient);
			client.Id = id;

			await _clientRepository.Update(client);
		}
	}
}
