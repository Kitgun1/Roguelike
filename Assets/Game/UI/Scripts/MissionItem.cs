using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MissionItem : MonoBehaviour, IMissionItem
{
    private string _tag;

    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _done;
    [SerializeField] private TMP_Text _need;
    [SerializeField] private ParticleSystem _particleComplited;

    private int _doneValue;
    private int _needValue;

    public event UnityAction<string> OnComplete;

    private enum ParameterType
    {
        Description,
        Done,
        Need,
        All
    }

    #region Get

    public string GetTag() => _tag;
    public string GetDescription() => _description.text;
    public int GetDoneValue() => _doneValue;
    public int GetNeedValue() => _needValue;

    #endregion

    #region Set

    public void SetTag(string name) => _tag = name;
    public void SetDescription(string text) => _description.text = text;

    public void SetDone(int value)
    {
        _doneValue = value;
        Display(ParameterType.Done);
    }

    public void SetNeed(int value)
    {
        _needValue = value;
        Display(ParameterType.Need);
    }

    #endregion

    #region Add

    public void AddDone(int value)
    {
        if (_needValue > value + _doneValue)
            _doneValue += _needValue - value;
        else
            _doneValue += value;

        Display(ParameterType.Done);

        if (_doneValue >= _needValue)
        {
            OnComplete?.Invoke(_tag);
            _particleComplited.Play();
        }
    }

    public void AddNeed(int value)
    {
        _needValue += value;
        Display(ParameterType.Need);
    }

    #endregion

    private void Display(ParameterType parameterType)
    {
        switch (parameterType)
        {
            case ParameterType.Done:
                _done.text = _doneValue.ToString();
                break;
            case ParameterType.Need:
                _need.text = _needValue.ToString();
                break;
            case ParameterType.All:
                _done.text = _doneValue.ToString();
                _need.text = _needValue.ToString();
                break;
            default:
                break;
        }
    }
}
