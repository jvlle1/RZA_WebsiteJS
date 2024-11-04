using System;
using System.Collections.Generic;

namespace RZA_WebsiteJS.Models;

public partial class Zooticket
{
    public int ZooticketsId { get; set; }

    public int ZoombookingId { get; set; }

    public int AttractionId { get; set; }

    public int? Fee { get; set; }

    public DateOnly? Bookingdate { get; set; }

    public virtual Attraction Attraction { get; set; } = null!;
}
