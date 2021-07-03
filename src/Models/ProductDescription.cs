﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Domain.Models
{
    // Product descriptions in several languages.
    public partial class ProductDescription
    {
        public ProductDescription()
        {
            ProductModelProductDescriptionCultures = new HashSet<ProductModelProductDescriptionCulture>();
        }

        public int ProductDescriptionId { get; set; }
        public string Description { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
    }
}
