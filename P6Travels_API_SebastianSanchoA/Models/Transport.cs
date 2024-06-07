using System;
using System.Collections.Generic;

namespace P6Travels_API_SebastianSanchoA.Models;

public partial class Transport
{
    public int TransportId { get; set; }

    public string TransportDescription { get; set; } = null!;

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();
}
