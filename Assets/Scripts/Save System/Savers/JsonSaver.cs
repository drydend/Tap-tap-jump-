using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class JsonSaver : ISaver
{
#if UNITY_EDITOR
    private string DataPath => Application.dataPath + "/SaveData.save";
#else

    private string DataPath => Application.persistentDataPath + "/SaveData.save";

#endif

    public SaveData LoadData()
    {
        if (!File.Exists(DataPath))
        {
            File.Create(DataPath);
            return new SaveData();
        }

        var json = File.ReadAllText(DataPath);

        if (string.IsNullOrEmpty(json))
        {
            return new SaveData();
        }

        return JsonConvert.DeserializeObject<SaveData>(json);
    }

    public void SaveData(SaveData data)
    {
        var jsonData = JsonConvert.SerializeObject(data);
        File.WriteAllText(DataPath, jsonData);
    }
}
