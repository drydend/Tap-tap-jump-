using System;
using System.Collections.Generic;

public class SaveService
{
    private List<ISaveable> _saveables = new List<ISaveable>();
    
    private Dictionary<Type, SaveData> _data = new Dictionary<Type, SaveData>();

    public void SubscribeToSaving(ISaveable saveable)
    {
        _saveables.Add(saveable);
    }

    public void UnsubscribeToSaving(ISaveable saveable)
    {
        _saveables.Remove(saveable);
    }
    public void Save()
    {
        foreach (var saveable in _saveables)
        {
            var data = saveable.GetSaveData();
            _data[data.GetType()] = data;
        }
    }

    public void LoadAllData()
    {
        
    }


    public T GetData<T>() where T : SaveData, new()
    {
        if (!_data.ContainsKey(typeof(T)))
        {
            return new T();
        }

        return (T) _data[typeof(T)];
    }
}
