using UnityEngine;

public class PlayerTransorter : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private LevelStarter _levelStarter;
    [SerializeField] private Player _player;

    private void OnLevelStarted()
    {
        _player.transform.SetParent(_level.CurrentRoom.transform, false);
    }

    private void OnEnable()
    {
        _levelStarter.LevelStarted += OnLevelStarted;
    }

    private void OnDisable()
    {
        _levelStarter.LevelStarted -= OnLevelStarted;
    }
}