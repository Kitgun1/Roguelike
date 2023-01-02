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
    private int _currentBundle;
    private int _spawned;

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
        _spawned = 0;
        ReturnRoom();
    }

    private void Update()
    {
        if (_spawning)
            HandleSpawn();
    }

    private void HandleSpawn()
    {
        LevelTrapsBundle current = _bundles[_currentBundle];

        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= current.SpawnDelay)
        {
            Spawn(current.Trap);

            _elapsedTime = 0;
            _spawned++;
            _bundles[_currentBundle] = current;
            
            if (_spawned >= current.Count)
                LoadNextBundle();
        }
    }

    private void Spawn(TrapControl trap)
    {
        _spawnedTraps.Add(Instantiate(trap, _parent));
    }

    private void LoadNextBundle()
    {
        if (_currentBundle < _bundles.Count - 1)
            _currentBundle++;
        else
            _spawning = false;
        _spawned = 0;
    }

    private void ReturnRoom()
    {
        foreach (var trap in _spawnedTraps)
        {
            Destroy(trap.gameObject);
        }
        foreach (var trap in _traps)
        {
            trap.ReturnToOrigin();
            trap.gameObject.SetActive(false);
        }

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