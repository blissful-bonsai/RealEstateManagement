using System;
using System.Collections.Generic;
using RealEstateManagement.Domain.ClientModule;

namespace RealEstateManagement.Web;

public partial class ContactMessage
{
    public int MessageId { get; set; }

    public int PropertyId { get; set; }

    public int ClientId { get; set; }

    public int AgentId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime DateSent { get; set; }

    public virtual Agent Agent { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual Property Property { get; set; } = null!;
}
