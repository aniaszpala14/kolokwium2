using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;

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