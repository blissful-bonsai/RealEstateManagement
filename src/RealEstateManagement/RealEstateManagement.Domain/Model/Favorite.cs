using System;
using System.Collections.Generic;
using RealEstateManagement.Domain.ClientModule;

namespace RealEstateManagement.Web;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int ClientId { get; set; }

    public int PropertyId { get; set; }

    public DateOnly DateAdded { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Property Property { get; set; } = null!;
}
