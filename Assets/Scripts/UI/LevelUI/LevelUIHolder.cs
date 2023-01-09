using System.Collections.Generic;
using UnityEngine;

public class LevelUIHolder : MonoBehaviour
{
    [SerializeField]
    private List<UIMenu> _levelUI;

    public T GetLevelUI<T>() where T : UIMenu
    {
        foreach (var ui in _levelUI)
        {
            if(typeof(T) == ui.GetType() || ui.GetType().IsSubclassOf(typeof(T)) )
            {
                return (T) ui;
            }
        }

        throw new System.Exception($"UI of type: {typeof(T)} - have not been added to list.");
    }
}
