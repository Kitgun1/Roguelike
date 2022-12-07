using UnityEngine.Events;

public interface IMissionItem
{
    public event UnityAction<string> OnComplete;

    #region Get

    public string GetTag();
    public string GetDescription();
    public int GetDoneValue();
    public int GetNeedValue();

    #endregion

    #region Set

    public void SetTag(string name);
    public void SetDescription(string text);

    public void SetDone(int value);

    public void SetNeed(int value);

    #endregion

    #region Add

    public void AddDone(int value);

    public void AddNeed(int value);

    #endregion
}