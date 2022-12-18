using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class PlayLastUnlockedLevelButton : MonoBehaviour
{
    [Inject]
    public void Construct(Game game)
    {
        GetComponent<Button>().onClick.AddListener(() => game.PlayLevel(game.LastUnlockedLevel));
    }


}
