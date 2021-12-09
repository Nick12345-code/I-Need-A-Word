using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void Save(GameData data)
    {
        string path = Application.persistentDataPath + "/data.player";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static GameData Load()
    {
        if (!File.Exists(GetPath()))
        {
            GameData emptyData = new GameData();
            Save(emptyData);
            return emptyData;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
        GameData data = formatter.Deserialize(fs) as GameData;
        fs.Close();
        return data;
    }

    public static void Delete()
    {
        string path = Application.persistentDataPath;
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete(true);
        Directory.CreateDirectory(path);
    }

    static string GetPath() => Application.persistentDataPath + "/data.player";
}
