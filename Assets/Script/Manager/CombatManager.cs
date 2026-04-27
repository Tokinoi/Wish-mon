using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
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
        SceneManager.LoadScene("World");
    }

    public void OpenBag()
    {
        Debug.Log("Opening Bag during Combat!");
    }

    public void OpenTeam()
    {
        Debug.Log("Opening MonsterPedia during Combat!");
    }

    public void openAttackMenu()
    {
        Debug.Log("Opening Attack Menu during Combat!");
    }
}
