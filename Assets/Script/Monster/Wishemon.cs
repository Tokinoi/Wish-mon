using UnityEngine;

public class Wishemon : MonoBehaviour
{
    public WishemonSaveData SaveData { get; private set; }
    public int CurrentHP { get; private set; }
    public int MaxHP { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Speed { get; private set; }
    public WishemonTypes Type { get; private set; }

    public Wishemon Initialize(WishemonSaveData saveData)
    {
        SaveData = saveData;
        CurrentHP = saveData.CurrentHP;
        MaxHP = saveData.Data.MaxHP;
        Attack = saveData.Data.Attack;
        Defense = saveData.Data.Defense;
        Speed = saveData.Data.Speed;
        Type = saveData.Data.Type;
        GameObject wishemon = Instantiate(saveData.Data.WishemonPrefab, transform);
        wishemon.transform.localPosition = Vector3.zero;
        wishemon.transform.localRotation = Quaternion.identity;
        return this;
    }
}
