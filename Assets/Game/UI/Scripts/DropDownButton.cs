using UnityEngine;
using KiUtilities.Switch.GameObjects;
using System.Collections;

public class DropDownButton : MonoBehaviour
{
    [SerializeField] private DropDownData _dropDown;

    private IEnumerator _isSwitches = null;

    private void Start()
    {
        _dropDown.Panel.SwitchGameObject(false);
        _dropDown.Button.SwitchGameObject(true);

        if(_dropDown.StartOnOpen && _isSwitches == null)
        _isSwitches = DelaySwitch(DropDownMode.Reveal, _dropDown.TimeAutoOpen);
        StartCoroutine(_isSwitches);
    }

    public void RevealDropDown(bool value = true)
    {
        DropDownMode mode = DropDownMode.Reveal;
        if (!value) mode = DropDownMode.Close;

        if (_isSwitches != null)
        {
            StopCoroutine(_isSwitches);
            _isSwitches = null;
        }

        _dropDown.Panel.SwitchGameObject(mode == DropDownMode.Reveal);
        _dropDown.Button.SwitchGameObject(!(mode == DropDownMode.Reveal));

        if (mode == DropDownMode.Reveal && _dropDown.TimeAutoClose != 0f)
        {
            _isSwitches = DelaySwitch(DropDownMode.Close, _dropDown.TimeAutoClose);
            StartCoroutine(_isSwitches);
            return;
        }
        if (mode == DropDownMode.Close && _dropDown.TimeAutoOpen != 0f)
        {
            _isSwitches = DelaySwitch(DropDownMode.Reveal, _dropDown.TimeAutoOpen);
            StartCoroutine(_isSwitches);
            return;
        }
    }

    private IEnumerator DelaySwitch(DropDownMode mode, float time)
    {
        yield return new WaitForSeconds(time);
        RevealDropDown(mode == DropDownMode.Reveal);
        _isSwitches = null;
    }
}

[System.Serializable]
public enum DropDownMode
{
    Reveal,
    Close
}

[System.Serializable]
public struct DropDownData
{
    public GameObject Button;
    public GameObject Panel;
    [Min(0)] public float TimeAutoClose;
    [Min(0)] public float TimeAutoOpen;
    public bool StartOnOpen;
}