
using VideoGameCharacterAPI.Model;

namespace VideoGameCharacterAPI.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterResponse>> GetAllCharacterAsync();

        Task<CharacterResponse?> GetCharacterByIdAsync(int id);

        Task<Character> AddCharacterAsync(Character character);

        Task<bool> UpdateCharacterAsync(int id, Character character);

        Task<bool> DeleteCharacterAync(int id);
    }
}
