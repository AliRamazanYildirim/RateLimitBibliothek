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
        //Get api/kunde/ali/28
        [HttpGet("{name}/{alter}")]
        public IActionResult GeheZuKunde(string name, int alter)
        {
            return Ok(name);
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
