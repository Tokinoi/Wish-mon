using UnityEngine;

[CreateAssetMenu(fileName = "Wishemon Card", menuName = "Config/Wishemon")]
public class WishemonData : ScriptableObject
{
    public string Name;
    public int Level;
    public int currentHP ;
    public int maxHP ;
    public int attack ;
    public int defense ;
    public int speed ;
    public WishemonTypes type ;
    public GameObject WishemonPrefab;
}