using UnityEngine;
using UnityEngine.SceneManagement;
public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    [SerializeField] private GameObject _wishemonSpawnPoint;
    [SerializeField] private GameObject _playerSpawnPoint;
    [SerializeField] private ProgressBar PlayerHealthBar;
    [SerializeField] private ProgressBar EnemyHealthBar;
    [SerializeField] private TypeChart _typesChart;
    private Wishemon _playerWishemon;
    private Wishemon _enemyWishemon;

  private void Awake()                            
  {                                      
    if (Instance != null && Instance != this) {   
    Destroy(gameObject); return; }
    Instance = this;                              
                             
  } 

  

  private void Start()
    {
        WishemonState playerData = GameManager.Instance.GetFirstWishemon();
        if (playerData == null) { FleeCombat(); return; }

        _playerWishemon = new GameObject("PlayerWishemon").AddComponent<Wishemon>();
        _playerWishemon.Initialize(playerData);
        _playerWishemon.transform.SetParent(_playerSpawnPoint.transform);
        _playerWishemon.transform.localPosition = Vector3.zero;
        _playerWishemon.transform.localRotation = Quaternion.identity;

        WishemonState enemyData = new WishemonState(GameManager.Instance.EncounteredWishemon);
        _enemyWishemon = new GameObject("EnemyWishemon").AddComponent<Wishemon>();
        _enemyWishemon.Initialize(enemyData);
        _enemyWishemon.transform.SetParent(_wishemonSpawnPoint.transform);
        _enemyWishemon.transform.localPosition = Vector3.zero;
        _enemyWishemon.transform.localRotation = Quaternion.identity;

        // TODO 

        EnemyHealthBar.SetMax(_enemyWishemon.State.MaxHP);
        EnemyHealthBar.SetValue(_enemyWishemon.State.CurrentHP);

        PlayerHealthBar.SetMax(_playerWishemon.State.MaxHP);
        PlayerHealthBar.SetValue(_playerWishemon.State.CurrentHP);

        
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
            int enemyHP = _enemyWishemon.State.TakeDamage(_playerWishemon.State.Attack,_playerWishemon.State.Type,_typesChart);
            EnemyHealthBar.SetValue(enemyHP);

            Debug.Log($"Type multiplier: {multiplier}");
            Debug.Log("Enemy HP: " + enemyHP);

            if (enemyHP <= 0)
            {
                Debug.Log("Enemy Defeated!");
                EndCombat(true);
            }

            int playerHP = _playerWishemon.State.TakeDamage(_enemyWishemon.State.Attack,_enemyWishemon.State.Type,_typesChart);
            PlayerHealthBar.SetValue(playerHP);
            Debug.Log("Player HP: " + playerHP);
    }

    public void EndCombat(bool playerWon)
    {
        if (playerWon)
        {
            Debug.Log("Player won the battle!");
        }
        else
        {
            Debug.Log("Player lost the battle!");
        }
        SceneManager.LoadScene("World");
    }


}