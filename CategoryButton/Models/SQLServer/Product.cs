using System;
using System.Collections.Generic;

namespace CategoryButton.Models.SQLServer
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
