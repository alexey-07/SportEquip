using System;
using System.Collections.Generic;

namespace SportEquip.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string NameUnit { get; set; } = null!;

    public virtual ICollection<ListOfSportingGood> ListOfSportingGoods { get; set; } = new List<ListOfSportingGood>();
}
