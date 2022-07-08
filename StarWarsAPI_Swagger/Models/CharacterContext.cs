using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsAPI.Models
{
    
    public class CharacterContext : DbContext
    {        
        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Character> Characters { get; set; }
    }
}
