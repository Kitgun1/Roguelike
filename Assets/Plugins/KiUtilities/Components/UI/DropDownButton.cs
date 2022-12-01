using UnityEngine;
using System.Collections;
using KiUtilities.Structures;
using KiUtilities.Switch.GameObjects;
using KiUtilities.Enums;

public class DropDownButton : MonoBehaviour
{
    [SerializeField] private DropDownData _dropDown;

    private IEnumerator _isSwitches = null;

    private void Start()
    {
        _dropDown.Panel.gameObject.SwitchGameObject(false);
        _dropDown.Button.gameObject.SwitchGameObject(true);

        if (_dropDown.AwakeOnStart && _isSwitches == null)
        {
            _isSwitches = DelaySwitch(_dropDown.StartMode, _dropDown.TimeAutoOpen);
            StartCoroutine(_isSwitches);
        }
    }

    public void SwitchDropDown(bool value = true)
    {
        DropDownMode mode = DropDownMode.Reveal;
        if (!value) mode = DropDownMode.Close;

        if (_isSwitches != null)
        {
            StopCoroutine(_isSwitches);
            _isSwitches = null;
        }

        _dropDown.Panel.gameObject.SwitchGameObject(mode == DropDownMode.Reveal);
        _dropDown.Button.gameObject.SwitchGameObject(!(mode == DropDownMode.Reveal));

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
        SwitchDropDown(mode == DropDownMode.Reveal);
        _isSwitches = null;
    }
}
