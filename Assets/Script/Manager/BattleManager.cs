using UnityEngine;
using UnityEngine.SceneManagement;
public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    [SerializeField] private GameObject _wishemonSpawnPoint;
    [SerializeField] private GameObject _playerSpawnPoint;
    [SerializeField] private GameObject PlayerHealthBar;
    [SerializeField] private GameObject EnemyHealthBar;
    

  private void Awake()                            
  {                                      
    if (Instance != null && Instance != this) {   
    Destroy(gameObject); return; }
    Instance = this;                              
                             
  } 

  private void Start()
    {
        WishemonSaveData playerData = GameManager.Instance.GetFirstWishemon();
        if (playerData == null) { FleeCombat(); return; }

        Wishemon playerWishemonInstance = new GameObject("PlayerWishemon").AddComponent<Wishemon>();
        playerWishemonInstance.Initialize(playerData);
        playerWishemonInstance.transform.SetParent(_playerSpawnPoint.transform);
        playerWishemonInstance.transform.localPosition = Vector3.zero;
        playerWishemonInstance.transform.localRotation = Quaternion.identity;

        WishemonSaveData enemyData = new WishemonSaveData(GameManager.Instance.EncounteredWishemon);
        Wishemon enemyWishemonInstance = new GameObject("EnemyWishemon").AddComponent<Wishemon>();
        enemyWishemonInstance.Initialize(enemyData);
        enemyWishemonInstance.transform.SetParent(_wishemonSpawnPoint.transform);
        enemyWishemonInstance.transform.localPosition = Vector3.zero;
        enemyWishemonInstance.transform.localRotation = Quaternion.identity;
    }

    // Create Wishemon
    // Handle dgt 
    // Handle turns

        public void StartCombat()
    {
        Debug.Log("Combat Started!");
    }

    public void EndCombat()
    {
        Debug.Log("Combat Ended!");
    }

    public void FleeCombat()
    {
        SceneManager.LoadScene(SceneNames.World);
    }

    public void OpenBag()
    {
        Debug.Log("Opening Bag during Combat!");
    }

    public void OpenTeam()
    {
        Debug.Log("Opening WishemonPedia during Combat!");
    }

    public void OpenAttackMenu()
    {
        Debug.Log("Opening Attack Menu during Combat!");
    }

}