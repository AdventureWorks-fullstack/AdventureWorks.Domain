using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Domain.Models
{
    public class LocationInventory
    {
        public LocationInventory()
        {
            ProductInventory = new HashSet<ProductInventory>();
        }

        public short LocationInventoryId { get; set; }
        public short LocationId { get; set; }
        public string Shelf { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<ProductInventory> ProductInventory { get; set; }
    }
}
