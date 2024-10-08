using System;
using System.Collections.Generic;
using RealEstateManagement.Domain.AgentModule;
using RealEstateManagement.Domain.ClientModule;

namespace RealEstateManagement.Web;

public partial class Property
{
    public int PropertyId { get; set; }

    public string Address { get; set; } = null!;

    public int Type { get; set; }

    public decimal Area { get; set; }

    public decimal Value { get; set; }

    public string? Description { get; set; }

    public int TransactionType { get; set; }

    public int? AgentTransactionId { get; set; }

    public int AgentManagerId { get; set; }

    public int OwnerClientId { get; set; }

    public bool Available { get; set; }

    public string? Photos { get; set; }

    public virtual Agent AgentManager { get; set; } = null!;

    public virtual Agent? AgentTransaction { get; set; }

    public virtual ICollection<ContactMessage> ContactMessages { get; set; } = new List<ContactMessage>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual Client OwnerClient { get; set; } = null!;
}
