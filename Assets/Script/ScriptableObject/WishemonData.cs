using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Wishemon Card", menuName = "Config/Wishemon")]
public class WishemonData : ScriptableObject
{
    public string Name;
    public int Level;

    public AnimationCurve experienceCurve;
    public AnimationCurve MaxHP;
    public AnimationCurve Attack;
    public AnimationCurve Defense;


    public WishemonTypes Type;
    public GameObject WishemonPrefab;

    public List<MoveLearnEntry> Learnset;
}