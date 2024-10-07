namespace RealEstateManagement.Domain.ClientModule
{
    public interface IClientService
    {
        void CreateClient(Client client);
        List<Client> GetClients();
        void SaveClient(Client client);
        Client GetById(int id);
        void Remove(int id);
    }
}

// Creates interface
// Implements on ServiceClient.cs