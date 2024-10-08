using RealEstateManagement.Domain.ClientModule;

namespace RealEstateManagement.Domain.AgentModule;

public interface IAgentRepository
{
    void CreateAgent(Agent Agent);
    List<Agent> GetAllAgents();
    void SaveAgent(Agent Agent);
    Agent GetAgent(string AgentId);
    void Remove(int id);
    bool GetAgentByCpf(string agentCpf, int agentId);
    bool GetAgentByCreci(string agentCreci, int agentId);

}










