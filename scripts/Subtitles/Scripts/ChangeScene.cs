using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    // Método para cambiar a la escena "Home"

    public Button buttonMenu;

    void Start()
    {
        // Encuentra todos los botones hijos y asigna el evento de clic
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        string sceneName = clickedButton.gameObject.name;
        // Antes de realizar el cambio de escena detectamos si el botón es "RA" 
        if (sceneName == "RA")
        {
            Debug.Log("Poner Loader");
        }

        SwitchScene(sceneName);
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }




    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene != null && scene.name == "RA")
        Debug.Log("Quitar Loader: ");
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}