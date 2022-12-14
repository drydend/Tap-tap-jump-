using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Slider))]  
public class LevelProgressBar : MonoBehaviour
{
    private Slider _slider;

    [SerializeField]
    private Transform _levelStartPosition;
    [SerializeField]
    private Transform _levelEndPosition;

    private Player _player;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        float progressValue = Mathf.InverseLerp(_levelStartPosition.position.y,
            _levelEndPosition.position.y, _player.transform.position.y);

        _slider.value = progressValue;
    }
}
