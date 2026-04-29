using UnityEngine;

public class HealCollider : NPCCollider
{
    override public void OnInteract()
    {
        GameManager.Instance.HealPlayer();
        DialogueManager.Instance.DisplayMessage("Your Wishemon have been healed!");
    }
}
