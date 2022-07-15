using System;
using System.Collections.Generic;

namespace TestTAL.Api.DA
{
    public partial class OccupationFactor
    {
        public OccupationFactor()
        {
            Occupations = new HashSet<Occupation>();
        }

        public int OccupationFactorId { get; set; }
        public string? Name { get; set; }
        public double? Factor { get; set; }

        public virtual ICollection<Occupation> Occupations { get; set; }
    }
}
