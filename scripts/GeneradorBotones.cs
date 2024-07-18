using UnityEngine;
using UnityEngine.UI;

public class GeneradorBotones : MonoBehaviour
{
    // Array de ejemplo con los items
    private Item[] items = new Item[5]
    {
        new Item { id = 1, nombre = "Item 1", rutaImagen = "ruta/imagen1.png" },
        new Item { id = 2, nombre = "Item 2", rutaImagen = "ruta/imagen2.png" },
        new Item { id = 3, nombre = "Item 3", rutaImagen = "ruta/imagen3.png" },
        new Item { id = 4, nombre = "Item 4", rutaImagen = "ruta/imagen4.png" },
        new Item { id = 5, nombre = "Item 5", rutaImagen = "ruta/imagen5.png" }
    };

    private void Awake()
    {
        // Buscar el GameObject donde se van a agregar los botones
        GameObject container = GameObject.Find("ContentNave1");
        if (container == null)
        {
            Debug.LogError("GameObject 'nave1' no encontrado.");
            return;
        }

        // Iterar sobre los items y crear un botón para cada uno
        foreach (Item item in items)
        {
            // Crear un nuevo GameObject para el botón
            GameObject ContainerButton = new GameObject("Button_" + item.nombre);

            // Establecer el transform parent al contenedor
            ContainerButton.transform.SetParent(container.transform, false);

            // Añadir el componente Button al GameObject
            Button button = ContainerButton.AddComponent<Button>();

            // Añadir un componente Image al GameObject para el aspecto visual del botón (opcional)
            Image image = ContainerButton.AddComponent<Image>();
            image.color = Color.white; // Color blanco como ejemplo

            // Configurar el tamaño y posición del RectTransform del botón
            RectTransform rectTransform = ContainerButton.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(160, 30); // Tamaño del botón
            rectTransform.localPosition = Vector3.zero; // Posición relativa al contenedor

            // Añadir texto al botón (opcional)
            GameObject textObject = new GameObject("Text");
            textObject.transform.SetParent(ContainerButton.transform, false);

            Text buttonText = textObject.AddComponent<Text>();
            buttonText.text = item.nombre; // Nombre del item como texto del botón
            buttonText.font = Resources.GetBuiltinResource<Font>("Anton.ttf");
            buttonText.alignment = TextAnchor.MiddleCenter;

            // Configurar el RectTransform del texto
            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
            textRectTransform.sizeDelta = rectTransform.sizeDelta;
            textRectTransform.localPosition = Vector3.zero;

            // Asignar listener para el evento de clic del botón
            button.onClick.AddListener(() => OnButtonClick(item));

            // Debug.Log("Botón creado para: " + item.nombre);
        }
    }

    // Método llamado cuando se hace clic en un botón
    void OnButtonClick(Item item)
    {
        Debug.Log("Botón clickeado para: " + item.nombre);
    }
}

// Clase para representar un Item
public class Item
{
    public int id;
    public string nombre;
    public string rutaImagen;
}
