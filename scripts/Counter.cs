using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Text countText;
    private int count;
    private int countInitialValue = 0;

    void Start()
    {
        
        countText = GetComponent<Text>();
        countInitialValue = int.Parse(countText.text);
        count = countInitialValue;
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = count.ToString();

    }

    public void OnIncrease () {
        count++;
    }

    public void OnDecrease()
    {
        count--;
    }

    public void OnReset()
    {
        count = countInitialValue;
    }
}
