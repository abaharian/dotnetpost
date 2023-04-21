
using Microsoft.AspNetCore.Mvc;

using dotnetpost.models;
using dotnetpost.managers;

namespace mabna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MabnaController : ControllerBase
    {
         private readonly TestManager _manager;
         private readonly ILogger _logger;

        public MabnaController(ILogger<MyDbContext> logger)
        {
            _manager = new TestManager();
            _logger = logger;
        }

        // 
        [HttpGet]
        public async Task<ActionResult<object>> TestResult()
        {
            try{
                var res = await _manager.GetTestResult();
                return Ok(new {
                    status = "Success",
                    count = res.Count(),
                    res = res
                });
            } catch (Exception e){
                 _logger.LogError("[Error] {DT} : {MSG}", 
                                   DateTime.UtcNow.ToLongTimeString(),
                                   e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
