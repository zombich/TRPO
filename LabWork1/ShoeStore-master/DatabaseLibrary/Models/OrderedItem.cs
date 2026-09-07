using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class OrderedItem
{
    public int OrderId { get; set; }

    public string Article { get; set; } = null!;

    public short Quantity { get; set; }

    public virtual Product ArticleNavigation { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
