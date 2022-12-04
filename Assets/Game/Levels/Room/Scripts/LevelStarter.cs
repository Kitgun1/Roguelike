using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Player _player;
    [SerializeField] private Level _level;

    public void StartGame()
    {
        _timer.StartCount();
        _player.StartLevel();
        _level.StartGame();
    }
}
