using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace kolos2.Models;

[Table("items")]
public class Item
{
    [Key]
    public int IdItem { get; set; }
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
    public int Weight { get; set; }

    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
}