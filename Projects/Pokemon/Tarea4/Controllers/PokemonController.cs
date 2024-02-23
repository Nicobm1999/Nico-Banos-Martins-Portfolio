using Microsoft.AspNetCore.Mvc;
using System;
using Tarea4.Models;

namespace Tarea4.Controllers
{



    public class PokemonController : Controller
    {

        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public List<Pokemon> team = new List<Pokemon>();

      


        [HttpGet]
        public IActionResult PokemonList()
        {
            var pokemons =  _pokemonRepository.GetAllPokemon();

            byte[] arrayBytes = HttpContext.Session.Get("team");
            if (arrayBytes == null)
            {
                team = new List<Pokemon>();
                HttpContext.Session.Set("team", _pokemonRepository.Serialize(team));
            }
            else
            {
                team = _pokemonRepository.Deserialize(arrayBytes);
            }

            int teamCount = team.Count;

            if (teamCount < 6)
            {
                ViewBag.TeamSlots = $"{team.Count} / 6";
            }
            else
            {
                ViewBag.TeamSlots = "Lleno";
            }

            if (pokemons == null || !pokemons.Any())
            {
                return NotFound();
            }

           
    

            return View(pokemons);
        }

        [HttpGet]
        public IActionResult FilterPokemonList(string tipo, string peso, string altura)
        {
            var data = _pokemonRepository.GetAllPokemon(); 

            
          
     
            if (!string.IsNullOrEmpty(tipo))
            {
                data = _pokemonRepository.GetFilterPokemonByType(tipo);

                ViewBag.Filter = ViewBag.Filter + " [Tipo: " + tipo + "]";
           
            }

            if (peso == "Ascendente")
            {
                data = data.OrderBy(x => x.Peso).ToList();
                ViewBag.Filter = ViewBag.Filter + " [Peso: Ascendente]";
            }
            else if (peso == "Descendente")
            {
                data = data.OrderByDescending(x => x.Peso).ToList();
                ViewBag.Filter = ViewBag.Filter + " [Peso: Descendente]";

            }

            if (!string.IsNullOrEmpty(altura) && int.TryParse(altura, out int alturaValue))
            {
                data = data.Where(x => x.Altura > alturaValue).ToList();
                ViewBag.Filter = ViewBag.Filter + " [Altura: > " + altura + "]";

            }
           
          

            return View("PokemonList", data);
        }

        [HttpGet]
        public IActionResult PokemonDetails(int numeroPokedex)
        {
            var pokemonDetails = _pokemonRepository.GetPokemonDetails(numeroPokedex);

            if (pokemonDetails == null)
            {
                return NotFound();
            }

            return View(pokemonDetails);
        }


        [HttpGet]
        public IActionResult RandomTeam()
        {
            var rndPokemons = _pokemonRepository.GetRandomPokemons();

            var num = rndPokemons.Count();

            var types = rndPokemons.SelectMany(pokemon => pokemon.Types).ToList();

            var type = types.GroupBy(t => t)
                                       .OrderByDescending(g => g.Count())
                                       .Select(g => g.Key)
                                       .FirstOrDefault();

            

            float weightAvg = (float)Math.Round(_pokemonRepository.WeightAverage(rndPokemons), 2);
            float heightAvg = (float)Math.Round(_pokemonRepository.HeightAverage(rndPokemons), 2);
            

            ViewBag.WeightAvg = weightAvg;
            ViewBag.HeightAvg = heightAvg;
            ViewBag.Type = type;
            ViewBag.N = num;

            return View(rndPokemons);
        }



        [HttpGet]
        public IActionResult MyTeam()
        {
            byte[] arrayBytes = HttpContext.Session.Get("team");
            if (arrayBytes == null)
            {
                team = new List<Pokemon>();
                HttpContext.Session.Set("team", _pokemonRepository.Serialize(team));
            }
            else
            {
                team = _pokemonRepository.Deserialize(arrayBytes);
            }

            var allTypes = _pokemonRepository.GetAllTypes();
            var pokeTypes = _pokemonRepository.GetAllPokeType();

            List<Tipo> GetPokemonTypes(int numeroPokedex)
            {
                return pokeTypes
                    .Where(pokemonTipo => pokemonTipo.Numero_Pokedex == numeroPokedex)
                    .Join(allTypes, pokemonTipo => pokemonTipo.Id_tipo, tipo => tipo.Id_tipo, (pokemonTipo, tipo) => tipo)
                    .ToList();
            }

            List<int> numbersPokedex = team.Select(t => t.Numero_Pokedex).ToList();
            List<Tipo> typeslist = numbersPokedex.SelectMany(GetPokemonTypes).ToList();
            List<string> types = typeslist.Select(t => t.Nombre).ToList();

            string type = types.GroupBy(t => t).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();

            int n1 = team.Count();

            float weightAvg = (float)Math.Round(_pokemonRepository.WeightAverage(team), 2);
            float heightAvg = (float)Math.Round(_pokemonRepository.HeightAverage(team), 2);

            ViewBag.WeightAvg = weightAvg;
            ViewBag.HeightAvg = heightAvg;
            ViewBag.Type = type;
            ViewBag.N1 = n1;



            return View(team);
        }

        public IActionResult AddToMyTeam(int numeroPokedex)
        {
            try
            {
                var pokemon = _pokemonRepository.GetPokemonById(numeroPokedex);

                byte[] arrayBytes = HttpContext.Session.Get("team");

                if (arrayBytes == null)
                {
                    team = new List<Pokemon>();
                    
                }
                else
                {
                    team = _pokemonRepository.Deserialize(arrayBytes);
                }
                if (team.Count < 6)
                {
                    team.Add(pokemon);
                }

                byte[] arrayBytes2 = _pokemonRepository.Serialize(team);
                HttpContext.Session.Set("team", arrayBytes2);

                return RedirectToAction("PokemonList", "Pokemon");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en AddToMyTeam: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpGet]
        public IActionResult Battle()
        {
            var randomTeam = _pokemonRepository.GetRandomPokemons();
            byte[] arrayBytes = HttpContext.Session.Get("team");
            List<Pokemon> team;

            if (arrayBytes == null)
            {
                team = new List<Pokemon>();
                HttpContext.Session.Set("team", _pokemonRepository.Serialize(team));
            }
            else
            {
                team = _pokemonRepository.Deserialize(arrayBytes);
            }

            var allTypes = _pokemonRepository.GetAllTypes();
            var pokeTypes = _pokemonRepository.GetAllPokeType();

            List<Tipo> GetPokemonTypes(int numeroPokedex)
            {
                return pokeTypes
                    .Where(pokemonTipo => pokemonTipo.Numero_Pokedex == numeroPokedex)
                    .Join(allTypes, pokemonTipo => pokemonTipo.Id_tipo, tipo => tipo.Id_tipo, (pokemonTipo, tipo) => tipo)
                    .ToList();
            }

            List<int> numbersPokedex = team.Select(t => t.Numero_Pokedex).ToList();
            List<Tipo> types2list = numbersPokedex.SelectMany(GetPokemonTypes).ToList();
            List<string> types2 = types2list.Select(t => t.Nombre).ToList();

            var types = randomTeam.SelectMany(pokemon => pokemon.Types).ToList();

            string type1 = types.GroupBy(t => t).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
            string type2 = types2.GroupBy(t => t).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();

            int n1 = randomTeam.Count();
            int n2 = team.Count();

            float weightAvg = (float)Math.Round(_pokemonRepository.WeightAverage(randomTeam), 2);
            float heightAvg = (float)Math.Round(_pokemonRepository.HeightAverage(randomTeam), 2);
            float weightAvg2 = (float)Math.Round(_pokemonRepository.WeightAverage(team), 2);
            float heightAvg2 = (float)Math.Round(_pokemonRepository.HeightAverage(team), 2);

            string team1 = "Ash Ketchum";
            string team2 = "Mi Equipo";

            var viewModel = new CombateViewModel
            {
                Team1 = (List<Pokemon>)randomTeam,
                Team2 = team,
                Winner = _pokemonRepository.Fight(type1,type2, weightAvg, weightAvg2, heightAvg, heightAvg2, team1, team2),
                WeightAvg1 = weightAvg,
                WeightAvg2 = weightAvg2,
                HeightAvg1 = heightAvg,
                HeightAvg2 = heightAvg2,
                TeamType1 = type1,
                TeamType2 = type2,
                Num1 = n1,
                Num2 = n2,
            };

    

             ViewBag.Team2Name = team2;
       
            return View("Battle", viewModel);
        }


        [HttpGet]
        public IActionResult RandomBattle()
        {
            var randomTeam = _pokemonRepository.GetRandomPokemons();

            var randomTeam2 = _pokemonRepository.GetRandomPokemons();

            var types = randomTeam.SelectMany(pokemon => pokemon.Types).ToList();

            var types2 = randomTeam2.SelectMany(pokemon => pokemon.Types).ToList();

            var type1 = types.GroupBy(t => t).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();

            var type2 = types2.GroupBy(t => t).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();

            int n1 = randomTeam.Count();
            int n2 = randomTeam2.Count();

            float weightAvg = (float)Math.Round(_pokemonRepository.WeightAverage(randomTeam), 2);
            float heightAvg = (float)Math.Round(_pokemonRepository.HeightAverage(randomTeam), 2);
            float weightAvg2 = (float)Math.Round(_pokemonRepository.WeightAverage(randomTeam2), 2);
            float heightAvg2 = (float)Math.Round(_pokemonRepository.HeightAverage(randomTeam2), 2);

            string team1 = "Ash Ketchum";
            string team2 = "Team Rocket";

            var viewModel = new CombateViewModel
            {
                Team1 = (List<Pokemon>)randomTeam,
                Team2 = (List<Pokemon>)randomTeam2,
                Winner = _pokemonRepository.Fight(type1, type2, weightAvg, weightAvg2, heightAvg, heightAvg2, team1, team2),
                WeightAvg1 = weightAvg,
                WeightAvg2 = weightAvg2,
                HeightAvg1 = heightAvg,
                HeightAvg2 = heightAvg2,
                TeamType1 = type1,
                TeamType2 = type2,
                Num1 = n1,
                Num2 = n2,

            };

            ViewBag.Team2Name = team2;
      

            return View("Battle",viewModel);
        }





        

    }
} 
