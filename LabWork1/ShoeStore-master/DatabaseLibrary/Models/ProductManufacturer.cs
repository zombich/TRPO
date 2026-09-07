using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class ProductManufacturer
{
    public int ManufacturerId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
