using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace kolos2.Models;

[Table("characters")]
public class Character
{
    [Key]
    public int IdCharacter { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(120)]
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }

    public ICollection<Character_title> CharacterTitles { get; set; } = new HashSet<Character_title>();
    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
}