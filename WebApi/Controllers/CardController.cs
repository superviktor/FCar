using Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController(IDbService dbService) : ControllerBase
{
    private readonly IDbService _dbService = dbService;

    [HttpGet]
    public IEnumerable<CardDto> List()
    {
        var cards = _dbService.ListCards(Guid.Parse("bd744305-bbce-4232-8959-d4185a741ed4"));
        return cards.Select(c => new CardDto
        {
            Front = c.Front,
            Back = c.Back
        });
    }


    [HttpPost]
    public IActionResult Add([Required] string front, [Required] string back)
    {
        _dbService.AddCard(Guid.Parse("bd744305-bbce-4232-8959-d4185a741ed4"), front, back);
        return Accepted();
    }
}
