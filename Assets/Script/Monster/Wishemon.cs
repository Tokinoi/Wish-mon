using UnityEngine;
[System.Serializable]
public class Wishemon : MonoBehaviour
{

    private WishemonData _data;

    public int level {get; private set;}
    public int currentHP {get; private set;}
    public int maxHP {get; private set;}
    public int attack {get; private set;}
    public int defense {get; private set;}
    public int speed {get; private set;}
    public WishemonTypes type {get; private set;}

    public Wishemon Initialize(WishemonData data)
    {
        _data = data;
        currentHP = data.currentHP;
        maxHP = data.maxHP;
        attack = data.attack;
        defense = data.defense;
        speed = data.speed;
        type = data.type;
        GameObject wishemon = Instantiate(data.WishemonPrefab,transform);
        wishemon.transform.localPosition = Vector3.zero;
        wishemon.transform.localRotation = Quaternion.identity;
        return this;
    }

    
}