using Microsoft.EntityFrameworkCore;
using kolos2.Models;
namespace kolos2.Data;
public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<Title> Titles { get; set; } = null!;
    public DbSet<Character_title> CharacterTitles { get; set; } = null!;
    public DbSet<Backpack> Backpacks { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Character>().HasData(new List<Character>
            {
                new Character{
                    IdCharacter = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    CurrentWeight = 12,
                    MaxWeight = 30
                },
                new Character{
                    IdCharacter = 2,
                    FirstName = "Janina",
                    LastName = "Kowalska",
                    CurrentWeight = 10,
                    MaxWeight = 20
                }
                ,new Character
                {
                    IdCharacter = 3,
                    FirstName = "Janusz",
                    LastName = "Drabina",
                    CurrentWeight = 15,
                    MaxWeight = 25
                }
                ,new Character
                {
                    IdCharacter = 4,
                    FirstName = "Joasia",
                    LastName = "Nowak",
                    CurrentWeight = 1,
                    MaxWeight = 10
                }
                ,new Character
                {
                    IdCharacter = 5,
                    FirstName = "Kasia",
                    LastName = "Farba",
                    CurrentWeight = 0,
                    MaxWeight = 45
                }
                ,new Character
                {
                    IdCharacter = 6,
                    FirstName = "Krzysztof",
                    LastName = "Krawczyk",
                    CurrentWeight = 12,
                    MaxWeight = 31000
                }
            });

            modelBuilder.Entity<Title>().HasData(new List<Title>
            {
                new Title
                {
                    IdTitle = 1,
                    Name = "Archer"
                },
                new Title
                {
                    IdTitle = 2,
                    Name = "Wizard"
                },
                new Title
                {
                    IdTitle = 3,
                    Name = "Ruler"
                },
                new Title
                {
                    IdTitle = 4,
                    Name = "Magician"
                },
                new Title
                {
                    IdTitle = 5,
                    Name = "Princess"
                },
                new Title
                {
                    IdTitle = 6,
                    Name = "Fighter"
                }
            });
           

            modelBuilder.Entity<Item>().HasData(new List<Item>
            {
                new Item{
                    IdItem = 1,
                    Name = "Glove",
                    Weight = 5
                },
                new Item {
                    IdItem = 2,
                    Name = "Sword",
                    Weight = 10
                },
                new Item{
                IdItem = 3,
                Name = "Goblin",
                Weight = 15
                },
                new Item {
                    IdItem = 4,
                    Name = "Hat",
                    Weight = 1
                },
                new Item {
                    IdItem = 5,
                    Name = "Mushroom",
                    Weight = 5
                },
                new Item {
                    IdItem = 6,
                    Name = "Pepper",
                    Weight = 12
                },
                new Item
                {
                    IdItem = 7,
                    Name = "Potion",
                    Weight = 3
                },
                new Item
                {
                    IdItem = 8,
                    Name = "Cat",
                    Weight = 13
                }
            });

            modelBuilder.Entity<Character_title>().HasData(new List<Character_title>
            {
                new Character_title
                {
                    IdCharacter = 1,
                    IdTitle = 1,
                    AcquiredAt = DateTime.Now
                },  
                new Character_title
                {
                    IdCharacter = 2,
                    IdTitle = 2,
                    AcquiredAt = DateTime.Now
                },
                new Character_title
                {
                    IdCharacter = 3,
                    IdTitle = 3,
                    AcquiredAt = DateTime.Now
                }
            });

            modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
            {
                new Backpack
                {
                    IdCharacter = 1,
                    IdItem = 1,
                    Amount = 2
                },
                new Backpack
                {
                    IdCharacter = 2,
                    IdItem = 2,
                    Amount = 1
                },
                new Backpack
                {
                    IdCharacter = 3,
                    IdItem = 3,
                    Amount = 2
                }
            });
    }
    
}