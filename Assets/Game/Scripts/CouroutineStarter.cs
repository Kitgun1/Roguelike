using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouroutineStarter : MonoBehaviour
{
    public static CouroutineStarter Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void StartCourutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
