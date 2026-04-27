using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class WishemonEncounter
{
    public WishemonData Wishemon;
    [Range(0f, 100f)] public float Chance;
}

[CreateAssetMenu(fileName = "GrassConfig", menuName = "Config/GrassZone")]
public class GrassConfig : ScriptableObject
{
    public List<WishemonEncounter> wishemonPool;
    [Range(0f, 1f)] public float encounterRate = 0.2f;
}  