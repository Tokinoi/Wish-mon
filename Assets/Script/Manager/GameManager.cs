using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public Vector3 _playerPosition = Vector3.zero;
    [SerializeField] public Quaternion _playerRotation = Quaternion.identity;

    public WishemonData EncounteredWishemon;
    public Dresseur CurrentDresseur;

    [SerializeField] public List<WishemonState> wishemonTeams = new List<WishemonState>();
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
    
    public WishemonState GetFirstWishemon()
    {
        for (int i = 0; i < wishemonTeams.Count; i++)
        {
            if (wishemonTeams[i].CurrentHP > 0)
                return wishemonTeams[i];
        }
        return null;
    }

    public void HealPlayer()
    {
        foreach (var wishemon in wishemonTeams)
        {
            wishemon.CurrentHP = wishemon.MaxHP;
        }
    }
    
    public void CaptureWishemon(WishemonState captured)
    {
        if(wishemonTeams.Count >= 6) { Debug.Log("Team is full!"); return; }    
        wishemonTeams.Add(captured);
    }

    public void StartBattle(Dresseur dresseur)
    {
        this.CurrentDresseur = dresseur;
        Debug.Log($"Starting battle with {dresseur.Name}");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }

}
