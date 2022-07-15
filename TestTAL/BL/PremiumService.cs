using TestTAL.Api.DA;

namespace TestTAL.Api.BL
{
    public class PremiumService : IPremiumService
    {
        private readonly TALContext _dbContext;
        public PremiumService(TALContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Occupation>> GetAllOccupations()
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                   return _dbContext.Occupations;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

        }
        public async Task<IEnumerable<OccupationFactor>> GetAllOccupationFactors()
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                   return _dbContext.OccupationFactors;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
