using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class MunicipalityTax
    {
        public int MunicipalityTaxId { get; set; }
        public int MunicipalityId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double Tax { get; set; }

        public virtual Municipality Municipality { get; set; }
    }
}
