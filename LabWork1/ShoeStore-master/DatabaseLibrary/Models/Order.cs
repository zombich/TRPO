using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseLibrary.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public int ReceiveCode { get; set; }

    public int OrderStatusId { get; set; }

    public int UserId { get; set; }
    [JsonIgnore]
    public virtual OrderStatus? OrderStatus { get; set; } = null!;
    [JsonIgnore]
    public virtual User? User { get; set; } = null!;
}
