using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public Vector3 _playerPosition = Vector3.zero;
    [SerializeField] public Quaternion _playerRotation = Quaternion.identity;

    public WishemonData EncounteredWishemon;

    public SaveData SaveData = new SaveData();

    public WishemonData getWishemonData()
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
    
    public WishemonData GetFirstWishemon()
    {
        int index = 0;
        while(SaveData._teamWishemon[index].currentHP <= 0)
        {
            Debug.Log("Wishemon " + SaveData._teamWishemon[index].currentHP + " is fainted. Checking next Wishemon...");
            index++;
        }
        return SaveData._teamWishemon[index];
    }

}
