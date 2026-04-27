using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public List<WishemonSaveData> _teamWishemon = new List<WishemonSaveData>();
    public List<WishemonSaveData> _boxWishemon = new List<WishemonSaveData>();
    public List<string> _capturedWishemonNames = new List<string>();
    public List<string> _encounteredWishemonNames = new List<string>();
    public List<ItemData> _inventoryItems = new List<ItemData>();
}
