using System;
using System.Collections.Generic;

namespace EF_DBFirst.Models;

public partial class Product
{
    public long ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public DateTime? DateOfPurchase { get; set; }

    public string? AvailabilityStatus { get; set; }

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public bool? Active { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }
}
