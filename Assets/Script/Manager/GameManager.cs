using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public Vector3 _playerPosition = Vector3.zero;
    [SerializeField] public Quaternion _playerRotation = Quaternion.identity;

    public WishemonData EncounteredWishemon;

    public SaveData SaveData = new SaveData();

    public WishemonData GetWishemonData()
    {
       return EncounteredWishemon;
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
    
    public WishemonSaveData GetFirstWishemon()
    {
        for (int i = 0; i < SaveData._teamWishemon.Count; i++)
        {
            if (SaveData._teamWishemon[i].CurrentHP > 0)
                return SaveData._teamWishemon[i];
        }
        return null;
    }

}
