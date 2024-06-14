namespace kolos2.DTOs;
public class CharacterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public List<BackpackItemDTO> BackpackItems { get; set; }
    public List<TitleDTO> Titles { get; set; }
}

public class BackpackItemDTO
{ 
    public string ItemName { get; set; }
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}

public class TitleDTO
{
    public string Title { get; set; }
    public DateTime AquiredAt { get; set; }
}

public class AddToBackpackDTO
{
    public int Amount { get; set; }
    public int IdItem { get; set; }
    public int IdCharacter { get; set; }

}