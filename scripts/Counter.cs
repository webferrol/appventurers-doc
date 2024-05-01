using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int secondsInitialValue = 1;
    private int secondsFinalValue = 10;
    private int seconds = 0;
    // Start is called before the first frame update
    void Start()
    {
        seconds = secondsInitialValue;
        InvokeRepeating("SecondsIncrement", 1f, 1f);
    }

    void SecondsIncrement()
    {
        if (seconds == secondsFinalValue) Cancel();
        Debug.Log(seconds);
        seconds++;
    }

    // Método para detener el contador
    public void Cancel()
    {
        CancelInvoke("SecondsIncrement");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
