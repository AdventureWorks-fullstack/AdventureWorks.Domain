using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorks.Domain.Models
{
    [Table(nameof(LocationInventoryHistory), Schema = "Production")]
    public class LocationInventoryHistory
    {
        public int LocationInventoryHistoryId { get; set; }
        public string LocationInventoryId { get; set; }
        public short LocationId { get; set; }
        public int ProductId { get; set; }
        public int BusinessEntityId { get; set; }
        public DateTime MovedHereWhen { get; set; }

        public virtual LocationInventory LocationInventory { get; set; }
        public virtual Product Product { get; set; }
        public virtual Employee MovedHereEmployee { get; set; }
    }
}
