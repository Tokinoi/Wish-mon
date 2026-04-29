using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class TypeRow
{
    public WishemonTypes attackerType;
    public List<float> multipliers; // index = defender
}

[CreateAssetMenu(fileName = "TypeChart", menuName = "Config/TypeChart")]
public class TypeChart : ScriptableObject
{
    public List<TypeRow> rows;

    public float GetMultiplier(WishemonTypes attacker, WishemonTypes defender)
    {
        TypeRow row = rows.Find(r => r.attackerType == attacker);
        if (row == null) return 1f;

        int index = (int)defender;

        if (index < 0 || index >= row.multipliers.Count)
            return 1f;

        return row.multipliers[index];
    }
}