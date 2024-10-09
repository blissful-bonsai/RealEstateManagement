using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Domain.AgentModule;
using RealEstateManagement.Domain.ClientModule;

namespace RealEstateManagement.DAO.Repositories.EF
{
    public class AgentRepository : IAgentRepository // 1. Initialization of the Repo
    {
        
        // We initialize a context to use in this repo only
        private readonly RealEstateDbContext _context; // This way, we don't depened on the DbContext file

        // Constructor, where do we
        public AgentRepository(RealEstateDbContext context)
        {
            _context = context; // When the controller needs IService, the DI defined at Program.cs: Creates new instance of AgentService, injects AgentRepository into AgentService and injects an instance of RealEstateDbContext into ClientRepository 
        }


        public List<Agent> GetAllAgents()
        {
            return _context.Agents.ToList();
        }

        public void CreateAgent(Agent agent)
        {
            _context.Agents.Add(agent);
            _context.SaveChanges();
        }
        
        public void SaveAgent(Agent agent)
        {
            _context.Update(agent);
            _context.SaveChanges();
        }

        public Agent GetAgent(int id)
        {
            return _context.Agents.FirstOrDefault(a => a.AgentId == id);
        }

        public void Remove(int id)
        {
            Agent agent = GetAgent(id);
            _context.Agents.Remove(agent);
            _context.SaveChanges();
        }

        public bool GetAgentByCpf(string agentCpf, int agentId)
        {
            return _context.Agents.Any(agent => string.Compare(agent.Cpf, agentCpf) == 0 && agent.AgentId != agentId);
        }

        public bool GetAgentByCreci(string agentCreci, int agentId)
        {
            return _context.Agents.Any(agent => string.Compare(agent.Creci, agentCreci) == 0 && agent.AgentId != agentId);
        }


    }
}
