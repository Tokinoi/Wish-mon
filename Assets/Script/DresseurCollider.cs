using UnityEngine;
using System.Collections.Generic;
public class DresseurCollider : NPCCollider
{
    [SerializeField] public Dresseur DresseurData;
    override public void OnInteract()
    {
        DialogueManager.Instance.DisplayMessage($"Hello, I'm {DresseurData.Name} and I have a team of Wishemon! Let's battle!");
        GameManager.Instance.StartBattle(DresseurData);
    }

}