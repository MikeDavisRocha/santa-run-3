using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveScore(CandiesController candiesController)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/score.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(candiesController);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadScore()
    {
        string path = Application.persistentDataPath + "/score.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
