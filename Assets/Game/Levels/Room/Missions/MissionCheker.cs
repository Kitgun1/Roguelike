using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionCheker : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Timer _timer;

    private void OnTick(float time)
    {
        LiveMission mission = (LiveMission)_level.CurrentRoom.Missions.Where(p => p is LiveMission).FirstOrDefault();

        if (mission != null)
        {
            if (time >= mission.Time)
                mission.CompleteMission();
        }
    }

    private void OnEnable()
    {
        _timer.OnTick += OnTick;
    }

    private void OnDisable()
    {
        _timer.OnTick -= OnTick;
    }
}
