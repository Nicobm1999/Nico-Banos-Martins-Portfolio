using Tarea4.Models;

namespace Tarea4.ViewModels
{
    public class PokemonDetailsViewModel
    {
        public Pokemon Pokemon { get; set; }
        public List<Pokemon> Evolutions { get; set; }
        public List<Movimiento> Moves { get; set; }
        public List<Pokemon> Involutions { get; set; }
    }
}
