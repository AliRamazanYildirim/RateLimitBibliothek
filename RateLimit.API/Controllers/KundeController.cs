using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateLimit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KundeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GeheZuKunde()
        {
            return Ok(new { Id = 1, Name = "Ali Ramazan", Alter = 28 });
        }
        [HttpPost]
        public IActionResult KundeSpeichern()
        {
            return Ok(new {Id=2, Name = "Rabia",Alter=28});
        }
        [HttpPut]
        public IActionResult KundeAktualisieren()
        {
            return Ok();
        }
    }
}
