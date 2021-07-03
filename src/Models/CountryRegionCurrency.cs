﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Domain.Models
{
    // Cross-reference table mapping ISO currency codes to a country or region.
    public partial class CountryRegionCurrency
    {
        public string CountryRegionCode { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual CountryRegion CountryRegionCodeNavigation { get; set; }
        public virtual Currency CurrencyCodeNavigation { get; set; }
    }
}
