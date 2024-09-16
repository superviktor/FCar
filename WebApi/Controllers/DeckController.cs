using Data;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController(IDbService dbService) : ControllerBase
{
    private readonly IDbService _dbService = dbService;

    [HttpGet]
    public IEnumerable<DeckDto> List()
    {
        var decks = _dbService.ListDecks(Guid.Parse("1e4efb5a-bf0d-4bdd-aaea-d480de1dbfce"));
        return decks.Select(d => new DeckDto
        {
            Name = d.Name
        });
    }
}
