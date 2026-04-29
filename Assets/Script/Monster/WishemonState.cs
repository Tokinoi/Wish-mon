using UnityEngine;
using System.Linq;

[System.Serializable]
public class WishemonState
{
    public WishemonData Data;

    public WishemonTypes Type => Data.Type;

    public int CurrentHP;
    public int Level;

    public int ExperienceToLevelUp => Mathf.RoundToInt(Data.experienceCurve.Evaluate(Level));   
    public int Experience = 0;

    public int MaxHP => Mathf.RoundToInt(Data.MaxHP.Evaluate(Level));
    public int Attack => Mathf.RoundToInt(Data.Attack.Evaluate(Level));
    public int Defense => Mathf.RoundToInt(Data.Defense.Evaluate(Level));

    public MoveData[] Moves;

    public WishemonState(WishemonData data)
    {
        Data = data;
        Level = data.Level;

        GenerateMoves();

        CurrentHP = MaxHP; 
    }

    public int TakeDamage(MoveData move, TypeChart typesChart)
    {
        
        float multiplier = typesChart.GetMultiplier(move.Type, Type);

        int baseDamage = move.Power - Defense;
        baseDamage = Mathf.Max(1, baseDamage);

        int finalDamage = Mathf.RoundToInt(baseDamage * multiplier);

        CurrentHP -= finalDamage;
        if (CurrentHP < 0) CurrentHP = 0;

        return CurrentHP;
    }

public void GenerateMoves()
{
    var availableMoves = Data.Learnset
        .Where(e => e.LevelUnlock <= Level)
        .Select(e => e.Move)
        .ToList();

    Moves = availableMoves
        .OrderBy(x => Random.value)
        .Take(4)
        .ToArray();
}
    public void GainXP(int amount)
    {
        Experience += amount;

        while (CanLevelUp())
        {
            LevelUp();
        }
    }

    public bool CanLevelUp()
    {
        return Experience >= ExperienceToLevelUp;
    }

    public void LevelUp()
    {
        Experience -= ExperienceToLevelUp;
        Level++;

        Debug.Log($"{Data.Name} leveled up to level {Level}!");

        CurrentHP = MaxHP;
    }

    public MoveData GetRandomMove()
    {
        return Moves[Random.Range(0, Moves.Length)];
    }

    public bool IsDead => CurrentHP <= 0;
}