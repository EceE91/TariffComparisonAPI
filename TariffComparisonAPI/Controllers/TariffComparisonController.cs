using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TariffComparisonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TariffComparisonController : ControllerBase
    {
        private readonly ITariffComparisonStrategy _tariffComparisonStrategy;

        private readonly ILogger<TariffComparisonController> _logger;

        public TariffComparisonController(ILogger<TariffComparisonController> logger, ITariffComparisonStrategy tariffComparisonStrategy)
        {
            _logger = logger;
            _tariffComparisonStrategy = tariffComparisonStrategy;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IProduct>> GetTariffComparisons(double consumption)
        {
            _logger.LogDebug($"Calculate tariff comparison with consumption value {consumption}");

            if(consumption <= 0)
            {
                _logger.LogError("Consumption value is equal to or smaller than 0");
                return BadRequest();
            }

            return _tariffComparisonStrategy.ListTariffComparison(consumption).ToList();
        }
    }
}
