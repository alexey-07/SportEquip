using System;
using System.Collections.Generic;

namespace SportEquip.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string NameManufacturer { get; set; } = null!;

    public virtual ICollection<ListOfSportingGood> ListOfSportingGoods { get; set; } = new List<ListOfSportingGood>();
}
