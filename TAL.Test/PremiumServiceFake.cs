using System.Collections.Generic;
using System.Threading.Tasks;
using TestTAL.Api.BL;

using System.Linq;
using TestTAL.Api.DA;

namespace TAL.Test
{
    
    public class PremiumServiceFake : IPremiumService
    {
        private readonly List<Occupation> _occupation;
        private readonly List<OccupationFactor> _occupationFactor;
        public PremiumServiceFake()
        {
            _occupation = new List<Occupation>()
            {
                new Occupation() { OccupationId = 1,
                    Name = "Cleaner", OccupationFactorId= 3},
              new Occupation() { OccupationId = 2,
                    Name = "Doctor", OccupationFactorId = 1},
              new Occupation() { OccupationId = 1,
                    Name = "Author", OccupationFactorId= 2},
            };

            _occupationFactor = new List<OccupationFactor>()
            {
                new OccupationFactor() { OccupationFactorId = 1,
                    Name = "Cleaner", Factor= 3},
              new OccupationFactor() { OccupationFactorId = 2,
                    Name = "Doctor", Factor= 1},
              new OccupationFactor() { OccupationFactorId = 1,
                    Name = "Author", Factor= 2},
            };
        }

        public async Task<IEnumerable<Occupation>> GetAllOccupations()
        {
            return (IEnumerable<Occupation>)Task.Run(() => _occupation);
        }

        public async Task<IEnumerable<OccupationFactor>> GetAllOccupationFactors()
        {
            return (IEnumerable<OccupationFactor>)Task.Run(() => _occupationFactor); 
        }
        }
}
