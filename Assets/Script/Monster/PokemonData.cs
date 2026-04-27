using UnityEngine;

[CreateAssetMenu(fileName = "PokemonData", menuName = "Config/Pokemon")]
public class PokemonData : ScriptableObject
{
    public string Name;
    public int Level;
    public int HP;
    public int Attack;
    public int Defense;
    public int Speed;
    public PokemonTypes types;
    public GameObject PokemonPrefab;
}