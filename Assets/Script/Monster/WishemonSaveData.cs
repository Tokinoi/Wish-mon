using UnityEngine;

[System.Serializable]
public class WishemonSaveData
{
    public WishemonData Data;
    public int CurrentHP;
    public int Level;

    public WishemonSaveData(WishemonData data)
    {
        Data = data;
        CurrentHP = data.MaxHP;
        Level = data.Level;
    }

    public WishemonSaveData(WishemonData data, int currentHP, int level)
    {
        Data = data;
        CurrentHP = currentHP;
        Level = level;
    }
}
