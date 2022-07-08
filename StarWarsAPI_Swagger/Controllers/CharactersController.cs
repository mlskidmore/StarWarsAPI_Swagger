using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarsAPI.Models;
using StarWarsAPI.Repositories;

namespace StarWarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepositiory;

        public CharactersController(ICharacterRepository characterRepositiory)
        {
            _characterRepositiory = characterRepositiory;
        }

        [HttpGet]
        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            return await _characterRepositiory.GetCharacters();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Character>> GetCharacter(int Id)
        {
            return await _characterRepositiory.GetCharacter(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter([FromBody] Character character)
        {
            var newCharacter = await _characterRepositiory.Create(character);

            return CreatedAtAction(nameof(GetCharacter), new {name = character.name}, newCharacter);
        }

        [HttpPut]
        public async Task<ActionResult> PutCharacter(int Id, [FromBody] Character character)
        {
            if (Id != character.Id)
            {
                return BadRequest();
            }

            await _characterRepositiory.UpdateCharacter(character);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCharacter(int Id)
        {
            var CharacterToDelete = await _characterRepositiory.GetCharacter(Id);

            if (CharacterToDelete == null)
            {
                return NotFound();
            }

            await _characterRepositiory.DeleteCharacter(CharacterToDelete.Id);

            return NoContent();
        }
    }
}
