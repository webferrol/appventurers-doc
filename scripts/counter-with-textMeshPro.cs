using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    private TMP_Text countText;
    public int count;
    private int countInitialValue = 0;

    // Start is called before the first frame update
    void Start()
    {

        countText = GetComponent<TMP_Text>(); // GETComponet Gets a reference to a component of type T on the specified GameObject.
        int.TryParse(countText.text, out countInitialValue);
        count = countInitialValue;
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = count.ToString();

    }

    public void OnIncrease()
    {
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

