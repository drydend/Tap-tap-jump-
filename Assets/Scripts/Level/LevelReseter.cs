using System.Collections.Generic;

public class LevelReseter
{
    private List<IResetable> _resetables = new List<IResetable>();

    public void ResetLevel()
    {
        foreach (var item in _resetables)
        {
            item.ResetState();
        }
    }

    public void Subscribe(IResetable resetable)
    {
        _resetables.Add(resetable);
    }

    public void UnSubscribe(IResetable resetable)
    {
        _resetables.Remove(resetable);
    }
}
