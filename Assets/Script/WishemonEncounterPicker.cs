using System.Collections.Generic;
using UnityEngine;

public static class WishemonEncounterPicker
{
    public static WishemonData Pick(List<WishemonEncounter> pool)
    {
        float total = 0f;
        foreach (var entry in pool)
            total += entry.Chance;

        float roll = Random.Range(0f, total);
        float cumulative = 0f;

        foreach (var entry in pool)
        {
            cumulative += entry.Chance;
            if (roll < cumulative)
                return entry.Wishemon;
        }

        return pool[pool.Count - 1].Wishemon;
    }
}
