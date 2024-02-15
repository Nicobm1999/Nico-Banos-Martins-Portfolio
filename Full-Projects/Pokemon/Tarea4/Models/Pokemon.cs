using System.Data.SqlClient;

namespace Tarea4.Models
{
    public class Pokemon
    {
        public int Numero_Pokedex { get; set; }
        public string Nombre { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
        public List<string> Types { get; set; }

     
      
    }
}
