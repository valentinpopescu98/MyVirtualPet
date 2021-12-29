using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    public static void SaveGame(uint level, uint maxXP, uint crtXP, Characters activeChar)
    {
        string path = GetSaveFilePath();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(level, maxXP, crtXP, activeChar);
        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static GameData LoadGame()
    {
        string path = GetSaveFilePath();

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    static string GetSaveFilePath()
    {
        return Application.persistentDataPath + "game";
    }
}
