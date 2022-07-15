using TestTAL.Api.DA;

namespace TestTAL.Api.BL
{
    public interface IPremiumService
    {
        public Task<IEnumerable<Occupation>> GetAllOccupations();
        public Task<IEnumerable<OccupationFactor>> GetAllOccupationFactors();
    }
}
