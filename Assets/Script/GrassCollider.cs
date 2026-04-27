using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassCollider : MonoBehaviour
{
    [SerializeField] private List<GameObject> _grassPrefabs = new();
    [SerializeField] private float _grassDensity = 1f;
    [SerializeField] private GrassConfig _config;
    private Player player = null;
    private float _currentProbability = 0f;


    private void Start()
    {
        if (_grassPrefabs == null || _grassPrefabs.Count == 0) return;

        GameObject container = new GameObject("GrassInstances");
        container.transform.SetParent(transform.parent);
        container.transform.position = Vector3.zero;

        Bounds bounds = GetComponent<Collider>().bounds;
        int grassCount = Mathf.RoundToInt(_grassDensity * bounds.size.x * bounds.size.z);
        for (int i = 0; i < grassCount; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                bounds.min.y,
                Random.Range(bounds.min.z, bounds.max.z)
            );
            GameObject prefab = _grassPrefabs[Random.Range(0, _grassPrefabs.Count)];
            Instantiate(prefab, position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f), container.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other is not CharacterController) return;
        player = other.GetComponent<Player>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other is not CharacterController) return;
        player = null;
    }

    private void Update()
    {
        if (player != null)
        {
            _currentProbability += _config.encounterRate * Time.deltaTime;
            float randomValue = Random.Range(0f, 100f);
            if (randomValue < _currentProbability)
            {
                _currentProbability = 0f;
                player.prepareCombat();
                GameManager.Instance.EncounteredPokemon = generateEncounter();
                SceneManager.LoadScene("Battle");
            }
        }

        if (player == null && _currentProbability > 0f)
        {
            _currentProbability = 0f; 
        }
    }

    private PokemonData generateEncounter()
    {
      float total = 0f;
      foreach (var entry in _config.pokemonPool)
          total += entry.Chance;

      float roll = Random.Range(0f, total);
      float cumulative = 0f;

      foreach (var entry in _config.pokemonPool)
      {
          cumulative += entry.Chance;
          if (roll < cumulative)
              return entry.Pokemon;
      }

      return _config.pokemonPool[_config.pokemonPool.Count - 1].Pokemon;

    }



}
