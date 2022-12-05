using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Player _player;
    [SerializeField] private Level _level;
    [SerializeField] private ButtonHandler _buttonHandler;

    public void StartGame()
    {
        _timer.StartCount();
        _player.StartLevel();
        _level.StartGame();
    }

    private void OnEnable()
    {
        _buttonHandler.OnClick += StartGame;
    }

    private void OnDestroy()
    {
        _buttonHandler.OnClick -= StartGame;
    }
}
