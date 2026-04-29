using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Config/Move")]
public class MoveData : ScriptableObject
{
    public string Name;
    public WishemonTypes Type;

    public int Power;
    public int Accuracy = 100;
}