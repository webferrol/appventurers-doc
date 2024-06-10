using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using Newtonsoft.Json;

public class GuardadoBoton : MonoBehaviour
{
    private string key = "BAG";
    private TextMeshProUGUI textoACambiar;



    // Método Start se llama antes de la primera actualización del frame
    void Start()
    {
        // Encuentra todos los GameObject de tipo botón que son hijos directos del GameObject y asigna el evento de clic
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }

        

    }

    public void CambiarTexto(TextMeshProUGUI textMeshPro, string nuevoTexto)
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = nuevoTexto;
        }
        else
        {
            Debug.LogWarning("TextMeshPro no asignado.");
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        if (clickedButton)
        {
            string nombrePersonaje = clickedButton.gameObject.name;
            AgregarPersonaje(nombrePersonaje);
        }
    }

    public void RecuperarUltimoPersonaje()
    {
        string json = PlayerPrefs.GetString(key);
        Debug.Log(json);
    }

    // Método para agregar un valor al conjunto guardado en PlayerPrefs
    public void AgregarPersonaje(string nuevoPersonaje)
    {
        // Obtener el JSON guardado previamente
        string json = PlayerPrefs.GetString(key);
        Debug.Log(json);

        HashSet<string> personajes;
        if (string.IsNullOrEmpty(json))
        {
            personajes = new HashSet<string>();
        }
        else
        {
            // Deserializar el JSON a un conjunto
            personajes = new HashSet<string>(JsonUtility.FromJson<Serialization<string>>(json).ToHashSet());
        }

        // Agregar el nuevo personaje al conjunto
        personajes.Add(nuevoPersonaje);

        // Serializar el conjunto a JSON
        json = JsonUtility.ToJson(new Serialization<string>(personajes));

        GameObject objetoTexto = GameObject.Find("TextoACambiar");
        if (objetoTexto != null)
        {
            textoACambiar = objetoTexto.GetComponent<TextMeshProUGUI>();
            if (textoACambiar != null)
            {
                // CambiarTexto(textoACambiar, "Texto inicial");
                
                CambiarTexto(textoACambiar, json);
            }
            else
            {
                Debug.LogWarning("No se encontró el componente TextMeshProUGUI en el objeto 'TextoACambiar'.");
            }
        }
        else
        {
            Debug.LogWarning("No se encontró el GameObject llamado 'TextoACambiar'.");
        }

        // objetoTexto.text = "TEXTO CAMBIADO";


        // Guardar la cadena JSON en PlayerPrefs
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    public void EliminarClave()
    {
        if (PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.DeleteKey(key);
            PlayerPrefs.Save();
            Debug.Log($"Clave '{key}' eliminada.");
        }
        else
        {
            Debug.Log($"Clave '{key}' no encontrada.");
        }
    }
}

// Clase auxiliar para serializar y deserializar conjuntos
[System.Serializable]
public class Serialization<T>
{
    public List<T> list;

    public Serialization(IEnumerable<T> enumerable)
    {
        list = new List<T>(enumerable);
    }

    public HashSet<T> ToHashSet()
    {
        return new HashSet<T>(list);
    }
}
