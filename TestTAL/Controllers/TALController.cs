using Microsoft.AspNetCore.Mvc;
using TestTAL.Api.BL;
using TestTAL.Api.Models;
using TestTAL.Models;

namespace TestTAL.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class TALController : ControllerBase
    {

        private readonly ILogger<TALController> _logger;
        internal IPremiumService _iPremiumService;

        public TALController(ILogger<TALController> logger, IPremiumService iPremiumService)
        {
            _logger = logger;
            _iPremiumService = iPremiumService;
        }

        [HttpGet]
        [Route("tal/GetOccupations")]
        public async Task<ActionResult<List<Occupation>>> GetOccupationsAsync()
        {
            try
            {
                var occupations = new List<Occupation>();
                var _occupations = await this._iPremiumService.GetAllOccupations();
                occupations.AddRange(_occupations.Select(occupation => occupation.ToOccupation()));
                return Ok(occupations);
            }
            catch (Exception e)
            {
                // if can't get DB instance working log the issue and return hard coded data.
                _logger.LogError(e.StackTrace);

                var occupations = new List<Occupation>();
                occupations.Add(new Occupation { OccupationID = 1, Name = "Cleaner", OccupationfactorID = 3 });
                occupations.Add(new Occupation { OccupationID = 2, Name = "Doctor", OccupationfactorID = 1 });
                occupations.Add(new Occupation { OccupationID = 3, Name = "Author", OccupationfactorID = 2 });
                occupations.Add(new Occupation { OccupationID = 4, Name = "Farmer", OccupationfactorID = 4 });
                occupations.Add(new Occupation { OccupationID = 5, Name = "Mechanic", OccupationfactorID = 4 });
                occupations.Add(new Occupation { OccupationID = 6, Name = "Florist", OccupationfactorID = 3 });
                return occupations;
            }

        }

        [HttpGet]
        [Route("tal/GetOccupationFactors")]
        public async Task<ActionResult<List<OccupationFactor>>> GetOccupationFactorsAsync()
        {
            try
            {
                var occupationFactors = new List<OccupationFactor>();
                var _occupationFactors = await this._iPremiumService.GetAllOccupationFactors();
                occupationFactors.AddRange(from occupationFactor in _occupationFactors
                                           select occupationFactor.ToOccupationFactor());
                return Ok(occupationFactors);
            }
            catch (Exception e)
            {
                // if can't get DB instance working log the issue and return hard coded data.
                _logger.LogError(e.StackTrace);
                var occupationFactors = new List<OccupationFactor>();
                occupationFactors.Add(new OccupationFactor { OccupationFactorID = 1, Name = "Professional", Factor = 1 });
                occupationFactors.Add(new OccupationFactor { OccupationFactorID = 2, Name = "White Collar", Factor = 1.25 });
                occupationFactors.Add(new OccupationFactor { OccupationFactorID = 3, Name = "Light Manual", Factor = 1.5 });
                occupationFactors.Add(new OccupationFactor { OccupationFactorID = 4, Name = "Heavy Manual", Factor = 1.75});
                return occupationFactors;
            }
        }
    }
}