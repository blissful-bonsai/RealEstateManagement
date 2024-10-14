using Microsoft.Extensions.Logging;

namespace RealEstateManagement.Domain.ClientModule;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly ILogger<ClientService> _logger;

    public ClientService(IClientRepository clientRepository, ILogger<ClientService> logger)
    {
        _clientRepository = clientRepository;
        _logger = logger;
    }   

    public void CreateClient(Client client)
    {
        _logger.LogInformation("Creating client");
        DuplicationValidation(client);
        _clientRepository.CreateClient(client);
    }

    public List<Client> GetClients()
    {
        return _clientRepository.GetAllClients(); // Before applying the ViewModel extension method 
    }

    public void SaveClient(Client client)
    {
        DuplicationValidation(client);
        _clientRepository.SaveClient(client);
    }

    public Client GetById(int id)
    {
        return _clientRepository.GetClientById(id);
    }

    public void Remove(int id)
    {
        _clientRepository.Remove(id);
    }

    private void DuplicationValidation(Client client)
    {
        // CPF duplication 
        var existingClientByCpf = _clientRepository.GetClientByCpf(client.Cpf, client.ClientId);

        if (existingClientByCpf is true)
        {
            _logger.LogWarning("A client with this CPF already exists");
            throw new ExistingClientException();
        }

        // Email duplication
        var existingClientByEmail = _clientRepository.GetClientByEmail(client.Email, client.ClientId);

        if(existingClientByEmail is true)
        {
            _logger.LogWarning("A client with this e-mail already exists");
            throw new ExistingClientException();
        }


    }
}