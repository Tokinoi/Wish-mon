using System.IO;
using UnityEngine;

public class SaveManager
{
    private static readonly string SaveFilePath = Path.Combine(Application.persistentDataPath, "savegame.json");

    public static void SaveGame()
    {
        string jsonData = JsonUtility.ToJson(GameManager.Instance.SaveData);
        File.WriteAllText(SaveFilePath, jsonData);
    }

    public static void LoadGame()
    {
        if (!File.Exists(SaveFilePath)) return;
        string jsonData = File.ReadAllText(SaveFilePath);
        JsonUtility.FromJsonOverwrite(jsonData, GameManager.Instance.SaveData);
    }
}
