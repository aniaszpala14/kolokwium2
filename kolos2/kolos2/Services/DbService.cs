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
              BackpackItems=c.Backpacks.Select(b=>new BackpackItemDTO
                                          {
                                              ItemName=b.Item.Name,
                                              ItemWeight=b.Item.Weight,
                                              Amount=b.Amount
                                          }).ToList(),
              Titles = c.CharacterTitles.Select(ct=>new TitleDTO
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
    public async Task<Character> GetCharacterInstance(int id)
    {return await _context.Characters.FirstOrDefaultAsync(c => c.IdCharacter == id); }
    public async Task<ICollection<Item>> ItemsToList(List<int> ids)
    { return await _context.Items.Where(i => ids.Contains(i.IdItem)).ToListAsync();}
    
    public async Task<ICollection<AddToBackpackDTO>> AddItemsToCharactersBackpack(ICollection<Item> items,List<int> itemsIds, Character character)
    {
        foreach (var item in items)
        {
            var hasItem = await _context.Backpacks.FirstOrDefaultAsync(b => b.IdCharacter == character.IdCharacter && b.IdItem == item.IdItem);//czy ma juz ten przedmiot

            if(hasItem!=null) 
            {hasItem.Amount+=1;} 
            else{
                var backpackItem= new Backpack{
                    IdCharacter=character.IdCharacter,
                    IdItem=item.IdItem,
                    Amount=1 
                };
                _context.Backpacks.Add(backpackItem);
            }
        }
        var itemsWeightSum= items.Sum(i => i.Weight); 
        character.CurrentWeight+= itemsWeightSum; //dodaje wage przedmiotow do wagi postaci
        await _context.SaveChangesAsync(); //uaktualniam wage current i asocjacje Backpack

        
        var result=await _context.Backpacks
            .Where(b => b.IdCharacter == character.IdCharacter && itemsIds.Contains(b.IdItem))
            .Select(b => new AddToBackpackDTO{ Amount=b.Amount, IdItem=b.IdItem, IdCharacter = b.IdCharacter })
            .ToListAsync();
        return result;
    }
}
