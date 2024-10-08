using RealEstateManagement.Domain.ClientModule;
// IClientRepository: IClientRepo
namespace RealEstateManagement.DAO.Repositories.EF
{
    public class ClientRepository : IClientRepository
    {
        private readonly RealEstateDbContext _context;

        public ClientRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        public void CreateClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public void SaveClient(Client client)
        {
            _context.Update(client);
            _context.SaveChanges();
        }

        public Client GetClientById(int? id)
        {
            return _context.Clients.FirstOrDefault(cliente => cliente.ClientId == id);
        }

        public void Remove(int id)
        {
            var client = GetClientById(id);
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        public bool GetClientByCpf(string clientCpf, int clientId)
        {
            return _context.Clients.Any(client => string.Compare(client.Cpf, clientCpf) == 0 && client.ClientId != clientId);
        }

        public bool GetClientByEmail(string clientEmail, int clientId)
        {
            return _context.Clients.Any(client => string.Compare(client.Email, clientEmail) == 0 && client.ClientId != clientId);
        }


    }
}