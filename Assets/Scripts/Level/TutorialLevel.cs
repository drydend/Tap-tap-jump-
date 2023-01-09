using System;
using System.Collections.Generic;

public class TutorialLevel : Level
{
    public override void OnLevelCompleated()
    {
        _game.OnTutorialCompleated();
    }
}
