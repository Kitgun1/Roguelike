using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerPresenter : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _stringLength;

    private const float Minute = 60;

    private void OnTick(float elapsed)
    {
        int currentLength = _stringLength;
        string text = "";
        string elapsedText = "";

        if (elapsed >= Minute)
        {
            int minutes = (int)(elapsed / Minute);
            int seconds = (int)(elapsed % Minute);
            elapsedText = minutes.ToString() + ":";
            if (seconds >= 10)
                elapsedText += seconds;
            else
                elapsedText += "0" + seconds;
        }
        else
        {
            elapsedText = elapsed.ToString();
        }

        currentLength = Mathf.Clamp(_stringLength, 0, elapsedText.Length);

        for (int i = 0; i < currentLength; i++)
        {
            if (elapsedText[i] != ',')
                text += elapsedText[i];
            else
                text += ".";
        }

        _text.text = text;
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
