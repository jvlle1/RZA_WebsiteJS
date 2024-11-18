using System;
using System.Collections.Generic;

namespace RZA_WebsiteJS.Models;

public partial class Attraction
{
    public int AttractionId { get; set; }

    public string? Name { get; set; }

    public float? Entryfee { get; set; }

    public virtual ICollection<Educationalticket> Educationaltickets { get; set; } = new List<Educationalticket>();

    public virtual ICollection<Zooticket> Zootickets { get; set; } = new List<Zooticket>();
}
