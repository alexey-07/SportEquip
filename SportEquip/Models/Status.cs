using System;
using System.Collections.Generic;

namespace SportEquip.Models;

public partial class Status
{
    public int Id { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<OrdersHistory> OrdersHistories { get; set; } = new List<OrdersHistory>();
}
