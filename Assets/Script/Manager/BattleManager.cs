using UnityEngine;
public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    [SerializeField] private GameObject _monsterSpawnPoint;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        createMonsterPrefab(GameManager.Instance.getMonsterData());
    }

    // Create Pokémon 
    // Handle dgt 
    // Handle turns

    private void createMonsterPrefab(PokemonData pokemonData)
    {
        GameObject monsterPrefab = pokemonData.PokemonPrefab;
        if (monsterPrefab != null)
        {
            Debug.Log("Instantiating monster prefab for " + pokemonData.Name);
            GameObject monster = Instantiate(monsterPrefab,_monsterSpawnPoint.transform);
            monster.transform.localPosition = Vector3.zero;
            monster.transform.localRotation = Quaternion.identity;
        }
        else
        {
            Debug.LogError("Monster prefab not found for " + pokemonData.Name);
        }
    }

}