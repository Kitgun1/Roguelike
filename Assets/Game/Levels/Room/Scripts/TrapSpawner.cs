using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] private List<LevelTrapsBundle> _bundles;
    [SerializeField] private List<TrapControl> _traps;
    [SerializeField] private Transform _parent;

    private List<TrapControl> _spawnedTraps = new List<TrapControl>();
    private bool _spawning = false;
    private float _elapsedTime;

    public void OnLevelStarted()
    {
        _spawning = true;

        foreach (var trap in _traps)
            trap.gameObject.SetActive(true);
    }

    public void OnLevelFinished()
    {
        _spawning = false;
        _elapsedTime = 0;
        ClearRoom();
    }

    private void Update()
    {
        if (_spawning)
        {
            _elapsedTime += Time.deltaTime;

        }
    }

    private void ClearRoom()
    {
        foreach (var trap in _spawnedTraps)
            Destroy(trap.gameObject);
        foreach (var trap in _traps)
            trap.gameObject.SetActive(false);

        _spawnedTraps.Clear();
    }
}

[System.Serializable]
public struct LevelTrapsBundle
{
    [field: SerializeField] public TrapControl Trap { get; private set; }
    [field: SerializeField] public float SpawnDelay { get; private set; }
    [field: SerializeField] public int Count { get; private set; }
}