using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missions : MonoBehaviour
{
    [SerializeField] private GameObject _template;

    private List<MissionItem> _missions = new List<MissionItem>();

    public void AddMission(string tagName, string description, int done, int need)
    {
        GameObject obj = Instantiate(_template, transform);
        var mission = obj.GetComponent<MissionItem>();
        _missions.Add(mission);

        mission.SetTag(tagName);
        mission.SetDescription(description);
        mission.SetDone(done);
        mission.SetNeed(need);
    }

    public void RemoveMission(string tagName)
    {
        for (int i = 0; i < _missions.Count; i++)
        {
            if (_missions[i].GetTag() == tagName)
            {
                Destroy(_missions[i].gameObject);
                _missions.RemoveAt(i);
                break;
            }
        }
    }
}
