using UnityEngine;

[CreateAssetMenu(fileName = "Move Config", menuName = "Config/Move")]
public class MoveConfig : ScriptableObject
{
    public string MoveName;
    public int Power;
    public int Accuracy;
    public int PP;
    public WishemonTypes Type;
}