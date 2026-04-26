using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public List<PokemonData> _teamPokemon= new List<PokemonData>();
    public List<PokemonData> _boxPokemon = new List<PokemonData>();
    public List<string> _capturedPokemonNames = new List<string>();
    public List<string> _defeatedTrainerNames = new List<string>();
    public List<string> _encounteredPokemonNames = new List<string>();
    public List<ItemData> _inventoryItems = new List<ItemData>();
    // Add more fields as needed for your game
}