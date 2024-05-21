using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    // Método para cambiar a la escena "Home"
    public void CambiarAHOME()
    {
        SceneManager.LoadScene("HOME");
    }

    // Método para cambiar a la escena "RA"
    public void CambiarARA()
    {
        SceneManager.LoadScene("RA");
    }

    // Método para cambiar a la escena "FAQS"
    public void CambiarAFAQS()
    {
        SceneManager.LoadScene("FAQS");
    }

    // Método para cambiar a la escena "Info"
    public void CambiarAINFO()
    {
        SceneManager.LoadScene("INFO");
    }

    // Método para cambiar a la escena "Maps"
    public void CambiarAMAPS()
    {
        SceneManager.LoadScene("MAPS");
    }
}
