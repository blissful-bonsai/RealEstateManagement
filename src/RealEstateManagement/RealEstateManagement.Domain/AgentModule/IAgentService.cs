namespace RealEstateManagement.Domain.AgentModule
{
    // This is a blueprint for the operations we will perform with this Type
    public interface IAgentService
    {
        void CreateAgent(Agent agent);
        List<Agent> GetAgents();
        void SaveAgent(Agent agent);
        Agent GetById(int id);
        void Remove(int id);
    }
}