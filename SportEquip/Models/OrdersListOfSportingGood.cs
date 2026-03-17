using System;
using System.Collections.Generic;

namespace SportEquip.Models;

public partial class OrdersListOfSportingGood
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdListOfSportingGoods { get; set; }

    public int Quantity { get; set; }

    public virtual ListOfSportingGood IdListOfSportingGoodsNavigation { get; set; } = null!;

    public virtual OrdersHistory IdOrderNavigation { get; set; } = null!;
}
