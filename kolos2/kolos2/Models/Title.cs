using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;
public class Title
{
    [Key]
    public int IdTitle { get; set; }

    [MaxLength(100)] [Required] 
    public string Name { get; set; } = string.Empty;

    public ICollection<Character_title> CharacterTitles { get; set; } = new HashSet<Character_title>();
}