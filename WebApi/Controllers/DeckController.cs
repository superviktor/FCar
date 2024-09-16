using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<DeckDto> List()
        {
            return [new DeckDto()];
        }
    }
}
