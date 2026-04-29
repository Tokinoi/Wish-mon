using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class TypeRow
{
    public WishemonTypes attackerType;
    public List<float> multipliers; // index = defender
}