using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using Microsoft.EntityFrameworkCore;

namespace kolos2.Models;

[Table("Character_Title")]
[PrimaryKey(nameof(IdCharacter), nameof(IdTitle))]
public class Character_title
{
    public int IdCharacter { get; set; }
    public int IdTitle { get; set; }
    [Required]
    public DateTime AcquiredAt { get; set; }
    
    [ForeignKey(nameof(IdCharacter))]
    public Character Character { get; set; } = null!;
    [ForeignKey(nameof(IdTitle))]
    public Title Title { get; set; } = null!;
}