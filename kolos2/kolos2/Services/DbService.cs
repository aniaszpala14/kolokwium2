using Microsoft.EntityFrameworkCore;
using kolos2.Data;
using kolos2.DTOs;
using kolos2.Models;
namespace kolos2.Services;
public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ICollection<CharacterDTO>> GetCharacter(int id)
    {
        var result = await _context.Characters
            .Include(c=> c.Backpacks)
                .ThenInclude(b=>b.Item)
            .Include(c=> c.CharacterTitles)
                .ThenInclude(ct=>ct.Title)
            .Where(c => c.IdCharacter==id)
            .Select(c=>new CharacterDTO
            {
              FirstName=c.FirstName,
              LastName=c.LastName,
              CurrentWeight=c.CurrentWeight,
              MaxWeight=c.MaxWeight,
              BackpackItems=c.Backpacks.Select(b=> new BackpackItemDTO
                                          {
                                              ItemName=b.Item.Name,
                                              ItemWeight=b.Item.Weight,
                                              Amount=b.Amount
                                          }).ToList(),
              Titles = c.CharacterTitles.Select(ct=> new TitleDTO
                                            {
                                              Title=ct.Title.Name,
                                              AquiredAt=ct.AcquiredAt
                                              
                                          }).ToList()
            })
            .ToListAsync();
        
        return result;

    }
    
    public async Task<bool> DoesCharacterExsist(int id)
    { return await _context.Characters.AnyAsync(c => c.IdCharacter == id); }
    
}
