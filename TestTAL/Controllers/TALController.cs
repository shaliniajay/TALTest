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

                _logger.LogError(e.StackTrace);
                return Problem();
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
                _logger.LogError(e.StackTrace);
                return Problem();
            }
        }
    }
}