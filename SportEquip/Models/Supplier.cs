using System;
using System.Collections.Generic;

namespace SportEquip.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string NameSupplier { get; set; } = null!;

    public virtual ICollection<ListOfSportingGood> ListOfSportingGoods { get; set; } = new List<ListOfSportingGood>();
}
