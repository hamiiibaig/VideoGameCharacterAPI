
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterAPI.Model;
using VideoGameCharacterAPI.Services;

namespace VideoGameCharacterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VediogamesCharacterController(
        IVideoGameCharacterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
        {
            return Ok(await service.GetAllCharacterAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);

            return character == null
                ? NotFound("Character with given id was not found")
                : Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> AddCharacter(Character character)
        {
            var result = await service.AddCharacterAsync(character);

            return CreatedAtAction(
                nameof(GetCharacter),
                new { id = result.Id },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, Character character)
        {
            var result = await service.UpdateCharacterAsync(id, character);

            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var result = await service.DeleteCharacterAync(id);

            return result ? NoContent() : NotFound();
        }
    }
}
