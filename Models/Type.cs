using System;
using System.Collections.Generic;

namespace RZA_WebsiteJS.Models;

public partial class Type
{
    public int TypeId { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
