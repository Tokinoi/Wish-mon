using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public List<WishemonData> _teamWishemon = new List<WishemonData>();
    public List<WishemonData> _boxWishemon = new List<WishemonData>();
    public List<WishemonData> _capturedWishemonNames = new List<WishemonData>();
    public List<WishemonData> _encounteredWishemonNames = new List<WishemonData>();
    public List<ItemData> _inventoryItems = new List<ItemData>();
    // Add more fields as needed for your game
}