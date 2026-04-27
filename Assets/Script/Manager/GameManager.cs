using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public Vector3 _playerPosition = Vector3.zero;
    [SerializeField] public Quaternion _playerRotation = Quaternion.identity;

    public PokemonData EncounteredPokemon;

    public SaveData SaveData = new SaveData();

    public PokemonData getMonsterData()
    {
       return EncounteredPokemon;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    

}
