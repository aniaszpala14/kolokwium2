using Microsoft.AspNetCore.Mvc;
using kolos2.DTOs;
using kolos2.Models;
using kolos2.Services;
namespace kolos2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;
    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacter(int characterId)
    {
        if(!await _dbService.DoesCharacterExsist(characterId))
        { return NotFound("W Bazie nie ma postaci o podanym ID"); }
        var character = await _dbService.GetCharacter(characterId);
        return Ok(character);
    }
    
    [HttpPost("{characterId}/backpacks")] //sprawdz Brak postaci,czy przemdioty istnieja,wolna ilosc udzwigu
    public async Task<IActionResult> AddItemToCharactersBackpack(int characterId,[FromBody] List<int> itemsIds)
    {
        if(!await _dbService.DoesCharacterExsist(characterId))
        { return NotFound("W Bazie nie ma postaci o podanym ID"); } 
        var character = await _dbService.GetCharacterInstance(characterId);

        var items = await _dbService.ItemsToList(itemsIds); //lista przedmiotow istniejacych
        if (items.Count != itemsIds.Count) { return BadRequest("Zla lista przedmiotow"); }
        
        var itemsWeightSum = items.Sum(i => i.Weight); 
        if (character.CurrentWeight + itemsWeightSum > character.MaxWeight)
        { return BadRequest("Waga rzeczy przekracza maksymalna wage udzwigu postaci"); }

        var result = await _dbService.AddItemsToCharactersBackpack(items,itemsIds,character);
        return Ok(result);
    }

}