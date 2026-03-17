using System;
using System.Collections.Generic;

namespace SportEquip;

public partial class Category
{
    public int Id { get; set; }

    public string NameCategory { get; set; } = null!;

    public virtual ICollection<Models.ListOfSportingGood> ListOfSportingGoods { get; set; } = new List<Models.ListOfSportingGood>();
}
