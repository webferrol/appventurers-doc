using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    public GameObject LoaderIcon;

    void Start()
    {
        // Encuentra todos los gameobject de tipo botón hijos directos del gameobject y asigna el evento de clic
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        // Coge el nombre del botón y lo guarda en un string que tiene que coincidir con el nombre de una escena (mirar el inspector)
        string sceneName = clickedButton.gameObject.name;
        Scene escenaActiva = SceneManager.GetActiveScene();
        string nombreEscenaActiva = escenaActiva.name;

        if (IsTheSceneDifferent(nombreEscenaActiva, sceneName))
        {
            if (sceneName == "RA")
            {
                LoaderIcon.SetActive(true);
                Debug.Log("Poner Loader");
            }
            StartCoroutine(SwitchSceneAsync(sceneName));
        }
    }

    IEnumerator SwitchSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Muestra el loader icon
        LoaderIcon.SetActive(true);

        // Espera hasta que la escena termine de cargar
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Oculta el loader icon
        LoaderIcon.SetActive(false);
        Debug.Log("Escena cargada: " + sceneName);
    }

    bool IsTheSceneDifferent(string nombreEscenaActiva, string sceneName)
    {
        return nombreEscenaActiva != sceneName;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene != null && scene.name == "RA")
        {
            Debug.Log("Quitar Loader");
        }
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
