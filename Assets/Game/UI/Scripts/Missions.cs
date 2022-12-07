using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missions : MonoBehaviour, IMission
{
    [SerializeField] private GameObject _template;

    private List<MissionItem> _missions = new List<MissionItem>();

    private void OnDisable()
    {
        foreach (var mission in _missions)
        {
            mission.OnComplete -= OnComplited;
        }
    }

    public void AddMission(string tagName, string description, int done, int need)
    {
        GameObject obj = Instantiate(_template, transform);
        var mission = obj.GetComponent<MissionItem>();
        _missions.Add(mission);

        mission.SetTag(tagName);
        mission.SetDescription(description);
        mission.SetDone(done);
        mission.SetNeed(need);

        mission.OnComplete += OnComplited;
    }

    public void ChangeMission(string tagName, string description = null, int? doneAdd = null, int? needAdd = null)
    {
        for (int i = 0; i < _missions.Count; i++)
        {
            if (_missions[i].GetTag() == tagName)
            {
                if (description != null)
                    _missions[i].SetDescription(description);

                if (doneAdd != null)
                    _missions[i].AddDone((int)doneAdd);

                if (needAdd != null)
                    _missions[i].AddNeed((int)needAdd);

                break;
            }
        }
    }

    public void RemoveMission(string tagName)
    {
        for (int i = 0; i < _missions.Count; i++)
        {
            if (_missions[i].GetTag() == tagName)
            {
                Destroy(_missions[i].gameObject);
                _missions[i].OnComplete -= OnComplited;
                _missions.RemoveAt(i);
                break;
            }
        }
    }

    private void OnComplited(string tag)
    {
        print($"{tag}: Mission complited");
    }
}
