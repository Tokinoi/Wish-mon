using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PokemonEncounter
{
    public PokemonData Pokemon;
    [Range(0f, 100f)] public float Chance;
}

[CreateAssetMenu(fileName = "GrassConfig", menuName = "Config/GrassZone")]
public class GrassConfig : ScriptableObject
{
    public List<PokemonEncounter> pokemonPool;
    [Range(0f, 1f)] public float encounterRate = 0.2f;
}  