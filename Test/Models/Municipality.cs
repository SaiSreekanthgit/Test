using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class Municipality
    {
        public Municipality()
        {
            MunicipalityTax = new HashSet<MunicipalityTax>();
        }

        public int MunicipalityId { get; set; }
        public string MunicipalityName { get; set; }

        public virtual ICollection<MunicipalityTax> MunicipalityTax { get; set; }
    }
}
