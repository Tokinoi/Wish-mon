using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Dresseur {
    public string Name;
    public List<WishemonState> Team;
    public WishemonState ChangePokemon()
    {
        // This method will be called when the player wants to switch to a different Wishemon during battle
        // For simplicity, we'll just return the first available Wishemon in the team
        foreach (var wishemon in Team)
        {
            if (wishemon != null && wishemon.CurrentHP >0) // Check if the slot is not empty
            {
                return wishemon; // Return a new instance of WishemonState based on the WishemonData
            }
        }
        return null; // No available Wishemon to switch to   
    }

}