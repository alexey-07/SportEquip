using System;
using System.Collections.Generic;

namespace SportEquip.Models;

public partial class ListOfSportingGood
{
    public int Id { get; set; }

    public string Articul { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int IdCategory { get; set; }

    public int IdManufactures { get; set; }

    public int IdSupplier { get; set; }

    public decimal Price { get; set; }

    public int IdUnit { get; set; }

    public string CurrentDiscount { get; set; } = null!;

    public string QuantityInStock { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Manufacturer IdManufacturesNavigation { get; set; } = null!;

    public virtual Supplier IdSupplierNavigation { get; set; } = null!;

    public virtual Unit IdUnitNavigation { get; set; } = null!;

    public virtual ICollection<OrdersListOfSportingGood> OrdersListOfSportingGoods { get; set; } = new List<OrdersListOfSportingGood>();
}
