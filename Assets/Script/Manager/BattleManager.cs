using UnityEngine;
using UnityEngine.SceneManagement;
public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    [SerializeField] private GameObject _wishemonSpawnPoint;
    [SerializeField] private GameObject _playerSpawnPoint;
    [SerializeField] private ProgressBar PlayerHealthBar;
    [SerializeField] private ProgressBar EnemyHealthBar;
    private int playerHP = 50;
    private int enemyHP = 50;

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

        EnemyHealthBar.SetMax(enemyHP);
        EnemyHealthBar.SetValue(enemyHP);
/*
        PlayerHealthBar.SetMax(playerData.Data.MaxHP);
        PlayerHealthBar.SetValue(playerData.CurrentHP);
*/
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
            enemyHP -= 10;
            EnemyHealthBar.SetValue(enemyHP);
            Debug.Log("Enemy HP: " + enemyHP);

            if (enemyHP <= 0)
            {
                Debug.Log("Enemy dead");
            }
    }

}