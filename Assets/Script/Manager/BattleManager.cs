using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    [SerializeField] private GameObject _wishemonSpawnPoint;
    [SerializeField] private GameObject _playerSpawnPoint;
    [SerializeField] private ProgressBar PlayerHealthBar;
    [SerializeField] private ProgressBar EnemyHealthBar;
    [SerializeField] private TypeChart _typesChart;

    [SerializeField] private GameObject _ActionChooser;
    [SerializeField] private GameObject _AttackMenu;
    [SerializeField] private GameObject _TeamMenu;

    private Wishemon _playerWishemon;
    private Wishemon _enemyWishemon;

  private void Awake()                            
  {                                      
    if (Instance != null && Instance != this) {   
    Destroy(gameObject); return; }
    Instance = this;                              
                             
  } 

  
    private void InitPlayerWishemon(WishemonState playerData)
    {
        if (_playerWishemon != null)
        {
            foreach (Transform child in _playerSpawnPoint.transform)
                {
                    Destroy(child.gameObject);
                }
        }
        _playerWishemon = new GameObject("PlayerWishemon").AddComponent<Wishemon>();
        _playerWishemon.Initialize(playerData);
        _playerWishemon.transform.SetParent(_playerSpawnPoint.transform);
        _playerWishemon.transform.localPosition = Vector3.zero;
        _playerWishemon.transform.localRotation = Quaternion.identity;       

    }

    private void InitEnemyWishemon(WishemonState enemyState)
    {
        if (_enemyWishemon != null)
        {
            foreach (Transform child in _wishemonSpawnPoint.transform)
                {
                    Destroy(child.gameObject);
                }
        }
        _enemyWishemon = new GameObject("EnemyWishemon").AddComponent<Wishemon>();
        _enemyWishemon.Initialize(enemyState);
        _enemyWishemon.transform.SetParent(_wishemonSpawnPoint.transform);
        _enemyWishemon.transform.localPosition = Vector3.zero;
        _enemyWishemon.transform.localRotation = Quaternion.identity;       
    }

  private void Start()
    {

        if(GameManager.Instance.EncounteredWishemon == null)
        {
            Debug.Log($"GameManager.Instance.CurrentDresseur: {GameManager.Instance.CurrentDresseur}");
            if(GameManager.Instance.CurrentDresseur != null)
            {

                InitEnemyWishemon(GameManager.Instance.CurrentDresseur.ChangePokemon());
            }
            else
            {
                Debug.LogError("No Wishemon or Dresseur to battle!");
                FleeCombat();
                return;
            }

        }else
        {
            InitEnemyWishemon(new WishemonState(GameManager.Instance.EncounteredWishemon));
        }


        
        WishemonState playerData = GameManager.Instance.GetFirstWishemon();
        if (playerData == null) { FleeCombat(); return; }

        InitPlayerWishemon(playerData);

;

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
        SceneManager.LoadScene("World 1");
    }

    public void OpenBag() //For now Capture then Bag 
    {
        if(_enemyWishemon.Capture())
        {
            GameManager.Instance.CaptureWishemon(_enemyWishemon.State);
            EndCombat(true);
        }
        else
        {
            Debug.Log("Failed to capture the enemy Wishemon!");
            int playerHP = _playerWishemon.State.TakeDamage(_enemyWishemon.State.GetRandomMove(),_typesChart);
            PlayerHealthBar.SetValue(playerHP);
        }
    }

    public void OpenTeam()
    {
        _TeamMenu.SetActive(true);
        _ActionChooser.SetActive(false);

        Button[] buttons = _TeamMenu.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            TextMeshProUGUI text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            if (i < GameManager.Instance.wishemonTeams.Count)
                text.text = GameManager.Instance.wishemonTeams[i].Data.Name;
            else
            {
                text.text = "";
                buttons[i].interactable = false;
            }
        }
        Debug.Log("Opening WishemonPedia during Combat!");
    }

    public void SwitchWishemon(int index)
    {
        if (index >= GameManager.Instance.wishemonTeams.Count) return;

        WishemonState newWishemonData = GameManager.Instance.wishemonTeams[index];
        if (newWishemonData.CurrentHP <= 0)
        {
            Debug.Log("Cannot switch to a fainted Wishemon!");
            return;
        }

        InitPlayerWishemon(newWishemonData);
        PlayerHealthBar.SetMax(_playerWishemon.State.MaxHP);
        PlayerHealthBar.SetValue(_playerWishemon.State.CurrentHP);

        _TeamMenu.SetActive(false);
        _ActionChooser.SetActive(true);

        Debug.Log($"Switched to {newWishemonData.Data.Name}!");
        
        int playerHP = _playerWishemon.State.TakeDamage(_enemyWishemon.State.GetRandomMove(),_typesChart);
        PlayerHealthBar.SetValue(playerHP);

    }

    public void ChooseMove(int moveIndex)
    {
        Debug.Log($"Player chose move {_playerWishemon.State.Moves[moveIndex].Name}!");
        Attack(_playerWishemon.State.Moves[moveIndex]);
    }

    public void OpenAttackMenu()
    {
        _AttackMenu.SetActive(true);
        _ActionChooser.SetActive(false);

        Button[] buttons = _AttackMenu.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            TextMeshProUGUI text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log($"Move {i}: {_playerWishemon.State.Moves[i].Name}");
            text.text = _playerWishemon.State.Moves[i].Name;
        }

        Debug.Log("Opening Attack Menu!");
    }

    public void Attack(MoveData move)
    {
            int enemyHP = _enemyWishemon.State.TakeDamage(move,_typesChart);
            EnemyHealthBar.SetValue(enemyHP);


            if (_enemyWishemon.State.IsDead)
            {
                _playerWishemon.State.GainXP(100);
                if (GameManager.Instance.CurrentDresseur != null)
            {
                WishemonState temp = GameManager.Instance.CurrentDresseur.ChangePokemon();
                if (temp != null)
                {
                    InitEnemyWishemon(temp);
                    EnemyHealthBar.SetMax(_enemyWishemon.State.MaxHP);
                    EnemyHealthBar.SetValue(_enemyWishemon.State.CurrentHP);
                    return;
                }
                else
                {
                    EndCombat(true);
                    return;
                }
            }
                 //TODO
                EndCombat(true);
                return;
            }

            int playerHP = _playerWishemon.State.TakeDamage(_enemyWishemon.State.GetRandomMove(),_typesChart);
            PlayerHealthBar.SetValue(playerHP);
        
        _AttackMenu.SetActive(false);
        _ActionChooser.SetActive(true);
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
        SceneManager.LoadScene("World 1");
    }


}