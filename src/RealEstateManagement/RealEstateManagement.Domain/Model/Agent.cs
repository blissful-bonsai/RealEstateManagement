using System;
using System.Collections.Generic;

namespace RealEstateManagement.Web;

public partial class Agent
{
    public int AgentId { get; set; }

    public string Name { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Creci { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<ContactMessage> ContactMessages { get; set; } = new List<ContactMessage>();

    public virtual ICollection<Property> PropertyAgentManagers { get; set; } = new List<Property>();

    public virtual ICollection<Property> PropertyAgentTransactions { get; set; } = new List<Property>();
}
