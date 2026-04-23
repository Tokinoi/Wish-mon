using UnityEngine;

public class GrassCollider : MonoBehaviour
{
    [SerializeField] private GameObject _grassPrefab = null;
    [SerializeField] private int _grassCount = 20;

    bool isPlayerInGrass = false;
    [SerializeField] private float _encounterProbability = 0.001f;
    private float _currentProbability = 0f;

    private void Start()
    {
        if (_grassPrefab == null) return;

        Bounds bounds = GetComponent<Collider>().bounds;
        for (int i = 0; i < _grassCount; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                bounds.min.y,
                Random.Range(bounds.min.z, bounds.max.z)
            );
            Instantiate(_grassPrefab, position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f), transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other is not CharacterController) return;
        isPlayerInGrass = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other is not CharacterController) return;
        isPlayerInGrass = false;
    }

    private void Update()
    {
        if (isPlayerInGrass)
        {
            _currentProbability += _encounterProbability;
            float randomValue = Random.Range(0f, 100f);
            if (randomValue < _currentProbability)
            {
                _currentProbability = 0f; 
                Debug.Log("A wild Pokémon appears!");
            }
        }

        if (!isPlayerInGrass && _currentProbability > 0f)
        {
            _currentProbability = 0f; 
        }
    }


}
