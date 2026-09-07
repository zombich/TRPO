using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class ProductSupplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
