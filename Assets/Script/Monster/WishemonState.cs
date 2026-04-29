[System.Serializable]
public class WishemonState
{
    public WishemonData Data;

    public WishemonTypes Type => Data.Type;

    public int CurrentHP;
    public int Level;

    public int MaxHP => Data.MaxHP;
    public int Attack => Data.Attack;
    public int Defense => Data.Defense;
    public int Speed => Data.Speed;

    public WishemonState(WishemonData data)
    {
        Data = data;
        CurrentHP = data.MaxHP;
        Level = data.Level;
    }

    public int TakeDamage(int amount, WishemonTypes attackType, TypesChart _typesChart)
    {
        
            float multiplier = _typesChart.GetMultiplier( 
                attackType, 
                Type   
            );

        CurrentHP -= amount;
        if (CurrentHP < 0) CurrentHP = 0;
        return CurrentHP;
    }

    public bool IsDead => CurrentHP <= 0;
}