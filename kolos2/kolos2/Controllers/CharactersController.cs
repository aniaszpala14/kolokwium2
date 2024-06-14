using System.Collections;
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
    
    

}