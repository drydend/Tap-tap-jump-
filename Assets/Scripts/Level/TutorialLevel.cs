public class TutorialLevel : Level
{
    public override void OnLevelCompleated()
    {
        _game.OnTutorialCompleated();
    }
}
