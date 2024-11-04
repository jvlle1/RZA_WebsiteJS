using System;
using System.Collections.Generic;

namespace RZA_WebsiteJS.Models;

public partial class Zoobooking
{
    public int CustomerId { get; set; }

    public int ZoobookingId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
