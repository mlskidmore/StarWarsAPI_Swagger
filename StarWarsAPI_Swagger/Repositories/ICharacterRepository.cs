using StarWarsAPI.Models;

namespace StarWarsAPI.Repositories
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetCharacters();

        Task<Character> GetCharacter(int Id);

        Task<Character> Create(Character character);

        Task UpdateCharacter(Character character);

        Task DeleteCharacter(int Id);

    }
}
