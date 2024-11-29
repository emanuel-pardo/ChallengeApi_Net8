using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bistrosoft.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BistrosoftController : ControllerBase
    {

        private readonly ILogger<BistrosoftController> _logger;
        private readonly IBSManager _manager;

        public BistrosoftController(ILogger<BistrosoftController> logger, IBSManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpGet(Name = "GetStatuses")]
        public async Task<IActionResult> GetStatusesAsync()
        {
            try
            {
                var statuses = await _manager.GetStatusesAsync();
                if (statuses == null)
                    throw new Exception("Error al obtener los estados de los sistemas");               

                return Ok(statuses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }


    }
}
