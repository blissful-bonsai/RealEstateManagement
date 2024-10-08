using RealEstateManagement.Domain.AgentModule;

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


        public List<Agent> GetAgents()
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

        }


    }
}