using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PanelInicio;
    public GameObject PanelAR;

    // Start is called before the first frame update
    void Start()
    {
        PanelInicio.SetActive(true);
        PanelAR.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {            
        PanelInicio.SetActive(false);
        PanelAR.SetActive(true);
    }

    public void ShowStartMenu()
    {
        PanelInicio.SetActive(true);
        PanelAR.SetActive(false);
    }
}
