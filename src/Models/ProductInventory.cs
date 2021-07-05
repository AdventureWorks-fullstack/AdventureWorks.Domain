using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Domain.Models
{
    // Product inventory information.
    public partial class ProductInventory
    {
        public int ProductId { get; set; }
        public short LocationId { get; set; }
        public short? LocationInventoryId { get; set; }
        public short Quantity { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
        public virtual LocationInventory LocationInventory { get; set; }
    }
}
