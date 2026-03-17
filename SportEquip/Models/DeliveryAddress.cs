using System;
using System.Collections.Generic;

namespace SportEquip.Models;

public partial class DeliveryAddress
{
    public int Id { get; set; }

    public string NameAddress { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<OrdersHistory> OrdersHistories { get; set; } = new List<OrdersHistory>();
}
