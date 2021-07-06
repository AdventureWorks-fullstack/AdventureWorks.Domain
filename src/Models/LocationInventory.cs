using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorks.Domain.Models
{
    [Table(nameof(LocationInventory), Schema = "Production")]
    public class LocationInventory
    {
        public LocationInventory()
        {
            ProductInventory = new HashSet<ProductInventory>();
            LocationInventoryHistory = new HashSet<LocationInventoryHistory>();
        }


        public string LocationInventoryId { get; set; }
        public short LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<LocationInventoryHistory> LocationInventoryHistory { get; set; }
        public virtual ICollection<ProductInventory> ProductInventory { get; set; }
    }
}
