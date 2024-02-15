using Tarea4.Models;

public class CombateViewModel
{
    public List<Pokemon> Team1 { get; set; }
    public List<Pokemon> Team2 { get; set; }
    public string Winner { get; internal set; }
    public float WeightAvg1 { get; set; }
    public float HeightAvg1{ get; set; }
    public string TeamType1 { get; set; }
    public int Num1 { get; set; }
    public float WeightAvg2 { get; set; }
    public float HeightAvg2 { get; set; }
    public string TeamType2 { get; set; }
    public int Num2 { get; set; }
}
