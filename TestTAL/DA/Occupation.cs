using System;
using System.Collections.Generic;

namespace TestTAL.Api.DA
{
    public partial class Occupation
    {
        public int OccupationId { get; set; }
        public string? Name { get; set; }
        public int? OccupationFactorId { get; set; }

        public virtual OccupationFactor? OccupationFactor { get; set; }
    }
}
