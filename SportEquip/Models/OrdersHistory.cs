using System;
using System.Collections.Generic;

namespace SportEquip.Models;

public partial class OrdersHistory
{
    public int Id { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public int IdDeliveryAddress { get; set; }

    public int IdUser { get; set; }

    public string Code { get; set; } = null!;

    public int IdStatus { get; set; }

    public virtual DeliveryAddress IdDeliveryAddressNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<OrdersListOfSportingGood> OrdersListOfSportingGoods { get; set; } = new List<OrdersListOfSportingGood>();
}
