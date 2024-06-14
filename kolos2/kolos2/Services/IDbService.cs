using kolos2.DTOs;
using kolos2.Models;
namespace kolos2.Services;

public interface IDbService
{
    Task<ICollection<CharacterDTO>> GetCharacter(int id);
    Task<bool> DoesCharacterExsist(int id);
    Task<Character> GetCharacterInstance(int id);
    Task<ICollection<Item>> ItemsToList(List<int> ids);
    Task<ICollection<AddToBackpackDTO>> AddItemsToCharactersBackpack(ICollection<Item> items,List<int> itemIds, Character character);
}
