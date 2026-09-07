using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DatabaseLibrary.Models;

public partial class Product
{
    [DisplayName("Артикул")]
    public string Article { get; set; } = null!;
    [DisplayName("Название")]
    public string Name { get; set; } = null!;
    [DisplayName("Ед. измерения")]
    public string Unit { get; set; } = null!;
    [DisplayName("Цена")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    [DisplayName("Скидка, %")]
    public byte Discount { get; set; }
    [DisplayName("Количество")]
    public byte Quantity { get; set; }
    [DisplayName("Описание")]
    public string Description { get; set; } = null!;
    [DisplayName("Фото")]
    public string? Photo { get; set; }

    public int SupplierId { get; set; }

    public int ManufacturerId { get; set; }

    [JsonIgnore]
    [DisplayName("Категория")]
    public virtual ProductCategory? Category { get; set; } = null!;
    [JsonIgnore]
    [DisplayName("Производитель")]
    public virtual ProductManufacturer? Manufacturer { get; set; } = null!;
    [JsonIgnore]
    [DisplayName("Поставщик")]
    public virtual ProductSupplier? Supplier { get; set; } = null!;
}
