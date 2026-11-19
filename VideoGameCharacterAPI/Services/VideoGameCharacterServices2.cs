

using Microsoft.EntityFrameworkCore;
using VideoGameCharacterAPI.data;
using VideoGameCharacterAPI.Model;

namespace VideoGameCharacterAPI.Services
{
    public class VideoGameCharacterServices(AppDbContext context)
        : IVideoGameCharacterService
    {
        // Get all characters
        public async Task<List<CharacterResponse>> GetAllCharacterAsync()
        {
            return await context.Characters
                .Select(c => new CharacterResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .ToListAsync();
        }

        // Get character by ID
        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            return await context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .FirstOrDefaultAsync();
        }

        // Add character
        public async Task<Character> AddCharacterAsync(Character character)
        {
            context.Characters.Add(character);
            await context.SaveChangesAsync();

            return character;
        }

        // Update character
        public async Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            var existingCharacter = await context.Characters
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existingCharacter == null)
                return false;

            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.Role = character.Role;

            await context.SaveChangesAsync();

            return true;
        }

        // Delete character
        public async Task<bool> DeleteCharacterAync(int id)
        {
            var character = await context.Characters
                .FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
                return false;

            context.Characters.Remove(character);
            await context.SaveChangesAsync();

            return true;
        }
    }
}

