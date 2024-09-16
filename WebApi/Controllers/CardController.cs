using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CardDto> List()
        {
            return [new CardDto()];
        }
    }
}
