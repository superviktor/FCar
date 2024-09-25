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
        return Ok(decks.Select(d => new DeckDto(d.Id, d.Name)));
    }

    [HttpPost]
    public ActionResult<DeckDto> Add(AddDeckRequest request)
    {
        _dbService.AddDeck(Guid.Parse("1e4efb5a-bf0d-4bdd-aaea-d480de1dbfce"), request.Name);
        return Ok();
    }

     //bd744305-bbce-4232-8959-d4185a741ed4
    [HttpGet("{deckId}/cards")]
    public IEnumerable<CardDto> ListCards(Guid deckId)
    {
        var cards = _dbService.ListCards(deckId);
        return cards.Select(c => new CardDto
        {
            Id = c.Id,
            Front = c.Front,
            Back = c.Back
        });
    }

    [HttpPost("{deckId}/cards")]
    public IActionResult Add(Guid deckId, AddCardRequest request)
    {
        _dbService.AddCard(deckId, request.Front, request.Back);
        return Accepted();
    }
}
