
namespace RealEstateManagement.Domain.ClientModule;

public interface IClientRepository
{
    void CreateClient(Client client);
    List<Client> GetAllClients();
    void SaveClient(Client client);
    Client GetClientById(int? id);
    void Remove(int id);
    bool GetClientByCpf(string clientCpf, int clientId);
    bool GetClientByEmail(string? clientEmail, int clientId);
}
