using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace kolos2.Models;
[Table("titles")]
public class Title
{
    [Key]
    public int IdTitle { get; set; }

    [MaxLength(100)] [Required] 
    public string Name { get; set; } = string.Empty;

    public ICollection<Character_title> CharacterTitles { get; set; } = new HashSet<Character_title>();
}