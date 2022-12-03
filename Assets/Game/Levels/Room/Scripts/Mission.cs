using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Mission", menuName = "CreateMissions/Missions", order = 1)]
public class Mission : ScriptableObject
{
    [field: SerializeField] public string Info { get; private set; }

    public event UnityAction<Mission> Complete;
}
