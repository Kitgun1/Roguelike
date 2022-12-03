using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionsPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _mission;
    [SerializeField] private Level _level;

    private void OnRoomChanged(Room room)
    {
        _mission.text = room.Missions[0].Info;
    }

    private void OnEnable()
    {
        _level.OnRoomChanged += OnRoomChanged;
    }

    private void OnDisable()
    {
        _level.OnRoomChanged -= OnRoomChanged;
    }
}