using Microsoft.EntityFrameworkCore;
using StarWarsAPI.Models;

namespace StarWarsAPI.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly CharacterContext _context;
        public CharacterRepository(CharacterContext context)
        {
            _context = context;
        }
        public async Task<Character> Create(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return character;
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetCharacter(int Id)
        {
            return await _context.Characters.FindAsync(Id);
        }

        public async Task UpdateCharacter(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCharacter(int Id)
        {
            var CharacterToDelete = await _context.Characters.FindAsync(Id);
            _context.Characters.Remove(CharacterToDelete);

            await _context.SaveChangesAsync();
        }
    }
}
