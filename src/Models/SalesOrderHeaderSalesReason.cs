using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Domain.Models
{
    // Cross-reference table mapping sales orders to sales reason codes.
    public partial class SalesOrderHeaderSalesReason
    {
        public int SalesOrderId { get; set; }
        public int SalesReasonId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual SalesOrderHeader SalesOrder { get; set; }
        public virtual SalesReason SalesReason { get; set; }
    }
}
