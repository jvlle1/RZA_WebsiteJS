using System;
using System.Collections.Generic;

namespace RZA_WebsiteJS.Models;

public partial class Educationalbooking
{
    public int CustomerId { get; set; }

    public int EducationalbookingId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
