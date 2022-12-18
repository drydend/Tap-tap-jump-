using System;
using System.Collections.Generic;

public class SaveService
{
    private SaveData _saveData;

    private ISaver _saver;
    public SaveService(ISaver saver)
    {
        _saver = saver;
    }

    public void Save(SaveData saveData)
    {
        _saver.SaveData(saveData);
    }

    public SaveData GetData()
    {
        if (_saveData == null)
        {
            _saveData = _saver.LoadData();
        }

        return _saveData;
    }
}
