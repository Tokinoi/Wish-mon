using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Wishemon Card", menuName = "Config/Wishemon")]
public class WishemonData : ScriptableObject
{
    public string Name;
    public int Level;
    public int MaxHP;
    public int Attack;
    public int Defense;
    public int Speed;

    public WishemonTypes Type;
    public GameObject WishemonPrefab;

    public List<MoveLearnEntry> Learnset;
}