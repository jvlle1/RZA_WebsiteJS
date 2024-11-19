using System;
using System.Collections.Generic;

namespace RZA_WebsiteJS.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int AttractionId { get; set; }

    public int TicketbookingId { get; set; }

    public virtual Attraction Attraction { get; set; } = null!;

    public virtual Ticketbooking Ticketbooking { get; set; } = null!;
}
