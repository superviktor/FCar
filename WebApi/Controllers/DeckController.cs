using Data;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Requests;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController(IDbService dbService) : ControllerBase
{
    private readonly IDbService _dbService = dbService;

    [HttpGet]
    public ActionResult<IEnumerable<DeckDto>> List()
    {
        var decks = _dbService.ListDecks(Guid.Parse("1e4efb5a-bf0d-4bdd-aaea-d480de1dbfce"));
        return Ok(decks.Select(d => new DeckDto
        {
            Name = d.Name
        }));
    }

    [HttpPost]
    public ActionResult<DeckDto> Add(AddDeckRequest request)
    {
        _dbService.AddDeck(Guid.Parse("1e4efb5a-bf0d-4bdd-aaea-d480de1dbfce"), request.Name);

        return Ok(new DeckDto
        {
            Name = request.Name
        });
    }
}
