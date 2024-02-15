using System.Data.SqlClient;
using Tarea4.ViewModels;

namespace Tarea4.Models
{
    public interface IPokemonRepository
    {
        IEnumerable<Pokemon> GetAllPokemon();
        IEnumerable<Tipo> GetAllTypes();
        IEnumerable<PokemonTipo> GetAllPokeType();
        IEnumerable<Pokemon> GetRandomPokemons();
        IEnumerable<Pokemon> GetFilterPokemonByType(string type);
        Pokemon GetPokemonById(int Pokedex);
        PokemonDetailsViewModel GetPokemonDetails(int pokedexNumber);
        List<Pokemon> Deserialize(byte[] arrayBytes);
        byte[] Serialize(List<Pokemon> team);
        float WeightAverage(IEnumerable<Pokemon> pokemons);
        float HeightAverage(IEnumerable<Pokemon> pokemons);
        string Fight(string type1, string type2, float weightAvg, float weightAvg2, float heightAvg, float heightAvg2, string team1, string team2);
    }

}
