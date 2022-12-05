using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event UnityAction OnClick;

    private void Click()
    {
        OnClick?.Invoke();
    }

    public void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Click);
    }

    public void OnDisable()
    {
        _button.onClick.RemoveListener(Click);
    }
}