using Dapper;
using NuGet.Protocol.Plugins;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;
using Tarea4.ViewModels;

namespace Tarea4.Models
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly Connection _conn;

        public PokemonRepository(Connection conexion)
        {
            _conn = conexion;
        }

        public static readonly Dictionary<string, List<string>> weaknesses = new Dictionary<string, List<string>>
        {
            { "Acero", new List<string> { "Lucha", "Fuego", "Tierra" } },
            { "Agua", new List<string> { "Planta", "Eléctrico" } },
            { "Bicho", new List<string> { "Volador", "Fuego", "Roca" } },
            { "Dragón", new List<string> { "Hada", "Hielo", "Dragón" } },
            { "Eléctrico", new List<string> { "Tierra" } },
            { "Fantasma", new List<string> { "Fantasma", "Siniestro" } },
            { "Fuego", new List<string> { "Tierra", "Agua", "Roca" } },
            { "Hada", new List<string> { "Acero", "Veneno" } },
            { "Hielo", new List<string> { "Lucha", "Acero", "Roca", "Fuego" } },
            { "Lucha", new List<string> { "Psíquico", "Volador", "Hielo" } },
            { "Normal", new List<string> { "Lucha" } },
            { "Planta", new List<string> { "Volador", "Bicho", "Veneno", "Hielo", "Fuego" } },
            { "Psíquico", new List<string> { "Bicho", "Fantasma", "Siniestro" } },
            { "Roca", new List<string> { "Lucha", "Tierra", "Acero", "Agua", "Planta" } },
            { "Siniestro", new List<string> { "Lucha", "Hada", "Bicho" } },
            { "Tierra", new List<string> { "Agua", "Planta", "Hielo" } },
            { "Veneno", new List<string> { "Tierra", "Psíquico" } },
            { "Volador", new List<string> { "Roca", "Hielo", "Eléctrico" } }
        };

       
         public IEnumerable<Pokemon> GetAllPokemon()
        {
            var query = "SELECT p.*, t.nombre AS NameType FROM pokemon p LEFT JOIN pokemon_tipo pt ON p.Numero_Pokedex = pt.Numero_Pokedex LEFT JOIN tipo t ON pt.Id_Tipo = t.Id_Tipo";

            using (var connection = _conn.GetConnection())
                {
                    var pokemonDictionary = new Dictionary<int, Pokemon>(); 
                    var pokemons = connection.Query<Pokemon, string, Pokemon>(
                        query, (pokemon, nameType) =>
                        {
                            if (!pokemonDictionary.TryGetValue(pokemon.Numero_Pokedex, out var thisPokemon))
                            {
                                thisPokemon = pokemon;
                                thisPokemon.Types = new List<string>();
                                pokemonDictionary.Add(thisPokemon.Numero_Pokedex, thisPokemon);
                            }
                            thisPokemon.Types.Add(nameType);
                            return thisPokemon;
                        },
                        splitOn: "NameType"
                    );
                    return pokemons.Distinct().ToList();
                }
        }

        public IEnumerable<Pokemon> GetRandomPokemons()
        {

            var query = $@"SELECT TOP 6 p.*, t.nombre AS NameType FROM pokemon p LEFT JOIN pokemon_tipo pt ON p.Numero_Pokedex = pt.Numero_Pokedex
                        LEFT JOIN tipo t ON pt.Id_Tipo = t.Id_Tipo ORDER BY NEWID()";

            using (var connection = _conn.GetConnection())
            {
                var pokemonDictionary = new Dictionary<int, Pokemon>();
                var pokemons = connection.Query<Pokemon, string, Pokemon>(
                    query, 
                    (pokemon, nameType) =>
                    {
                        if (!pokemonDictionary.TryGetValue(pokemon.Numero_Pokedex, out var thisPokemon))
                        {
                            thisPokemon = pokemon;
                            thisPokemon.Types = new List<string>();
                            pokemonDictionary.Add(thisPokemon.Numero_Pokedex, thisPokemon);
                        }
                        thisPokemon.Types.Add(nameType);
                        return thisPokemon;
                    },
                    splitOn: "NameType"
                );
                return pokemons.Distinct().ToList();
            }
        }

        public IEnumerable<Tipo> GetAllTypes()
        {
            var query = "SELECT * FROM tipo";
            using (var connection = _conn.GetConnection())
            {
                var tipos =connection.Query<Tipo>(query);
                return tipos.ToList();
            }
        }

        public IEnumerable<PokemonTipo> GetAllPokeType()
        {
            var query = "SELECT * FROM pokemon_tipo";
            using (var connection = _conn.GetConnection())
            {
                var tipos = connection.Query<PokemonTipo>(query);
                return tipos.ToList();
            }
        }

        public Pokemon GetPokemonById(int Pokedex)
        {
            using (var connection = _conn.GetConnection())
            {
                return connection.QueryFirstOrDefault<Pokemon>(
                    "SELECT p.*, t.nombre AS NombreTipo FROM pokemon p LEFT JOIN pokemon_tipo pt ON p.Numero_Pokedex = pt.Numero_Pokedex LEFT JOIN tipo t ON pt.Id_Tipo = t.Id_Tipo WHERE p.Numero_Pokedex = @Pokedex",
                    new { Pokedex }
                );
            }
        }

        
        public PokemonDetailsViewModel GetPokemonDetails(int Pokedex)
        {
            using (var connection = _conn.GetConnection())
            {
                var pokemon =  connection.QueryFirstOrDefault<Pokemon>(
                    "SELECT * FROM pokemon WHERE numero_pokedex = @Pokedex",
                    new { Pokedex }
                );
                if (pokemon == null)
                {
                    return null;
                }
                var evo =  connection.Query<Pokemon>(
                    "SELECT p.* FROM evoluciona_de e JOIN pokemon p ON e.pokemon_evolucionado = p.numero_pokedex WHERE e.pokemon_origen = @Pokedex",
                    new { Pokedex }
                );
                var invo =  connection.Query<Pokemon>(
                      "SELECT p.* FROM evoluciona_de e JOIN pokemon p ON e.pokemon_origen = p.numero_pokedex WHERE e.pokemon_evolucionado = @Pokedex",
                      new { Pokedex }
                  );
                var mov =  connection.Query<Movimiento>(
                    "SELECT m.* FROM pokemon_movimiento_forma pmf JOIN movimiento m ON pmf.id_movimiento = m.id_movimiento WHERE pmf.numero_pokedex = @Pokedex",
                    new { Pokedex }
                );
                var detallesPokemon = new PokemonDetailsViewModel
                {
                    Pokemon = pokemon,
                    Involutions= invo.ToList(),
                    Evolutions = evo.ToList(),
                    Moves = mov.ToList()
                };
                return detallesPokemon;
            }
        }

        public IEnumerable<Pokemon> GetFilterPokemonByType(string type)
        {
            var query = "SELECT * FROM pokemon WHERE (@Tipo IS NULL OR EXISTS (SELECT 1 FROM pokemon_tipo pt JOIN tipo t ON pt.id_tipo = t.id_tipo WHERE pt.numero_pokedex = pokemon.numero_pokedex AND t.nombre = @Tipo))";
            using (var connection = _conn.GetConnection())
            {
                var parameters = new
                {
                    Tipo = string.IsNullOrEmpty(type) ? null : type,
                   
                };

                var pokemonsByType = connection.Query<Pokemon>(query, parameters);
                return pokemonsByType.ToList();
            }
        }

        public byte[] Serialize(List<Pokemon> team)
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize(team);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        public List<Pokemon> Deserialize(byte[] arrayBytes)
        {
            string jsonString = Encoding.UTF8.GetString(arrayBytes);
            return System.Text.Json.JsonSerializer.Deserialize<List<Pokemon>>(jsonString);
        }

        public float WeightAverage(IEnumerable<Pokemon> pokemons)
        {
            float totalWeight = pokemons.Sum(p => p.Peso);
            return totalWeight / pokemons.Count();
        }

        public float HeightAverage(IEnumerable<Pokemon> pokemons)
        {
            float totalHeight = pokemons.Sum(p => p.Altura);
            return totalHeight / pokemons.Count();
        }


        /*  Como no entendia muy bien el funcionamiento del combate decidí crear el diccionario de tipos y sus debilidades y en vez de enfrentar a los pokemon 1 vs 1. Enfrenté los tipos predominantes
        de cada equipo y en caso de empate sus pesos medios y luego sus alturas medias. */

        public string Fight(string type1, string type2, float weightAvg, float weightAvg2, float heightAvg, float heightAvg2, string team1, string team2)
        {
            string winner = "";

            // Verificar si hay datos nulos relacionados con el equipo
            if ( string.IsNullOrEmpty(type2))
            {
                winner = "¡EQUIPO VACÍO! -> Debes añadir Pokémons a tu equipo haciendo click en las PokeBall de la lista de Pokémon";
            }
            else
            {
                if (weaknesses.ContainsKey(type1) && weaknesses.ContainsKey(type2))
                {
                    if (weaknesses[type1].Contains(type2))
                    {
                        winner = team2 + " por TIPO PREDOMINANTE " + "(" + type1 + " vs " + type2 + ")";
                    }
                    else if (weaknesses[type2].Contains(type1))
                    {
                        winner = team1 + " por TIPO PREDOMINANTE " + "(" + type1 + " vs " + type2 + ")";
                    }
                    else
                    {
                        if (weightAvg > weightAvg2)
                        {
                            winner = team1 + " por PESO MEDIO " + "(" + weightAvg + "Kg vs " + weightAvg2 + "Kg)";
                        }
                        else if (weightAvg < weightAvg2)
                        {
                            winner = team2 + " por PESO MEDIO " + "(" + weightAvg + "Kg vs " + weightAvg2 + "Kg)";
                        }
                        else
                        {
                            if (heightAvg > heightAvg2)
                            {
                                winner = team1 + " por ALTURA MEDIA " + "(" + heightAvg + "m vs " + heightAvg2 + "m)";
                            }
                            else if (heightAvg < heightAvg2)
                            {
                                winner = team2 + " por ALTURA MEDIA " + "(" + heightAvg + "m vs " + heightAvg2 + ")m";
                            }
                        }
                    }
                }
            }

            return winner;
        }


    }

}
