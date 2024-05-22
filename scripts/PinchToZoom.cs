using UnityEngine;
using UnityEngine.EventSystems;

// Para aplicar el script se debe arrastar simplemente encima de la imagen como un nuevo componente

public class PinchToZoom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isScaling;
    private float initialDistance;
    private Vector3 initialScale;
    public float maxScale = 2.0f; // Ajusta este valor según sea necesario

    void Start()
    {
        // Guarda la escala inicial del objeto
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (Input.touchCount == 2 && isScaling)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float scaleFactor = currentDistance / initialDistance;

                // Calcula la nueva escala
                Vector3 newScale = initialScale * scaleFactor;

                // Asegúrate de que la nueva escala no sea menor que la escala inicial y no supere el máximo
                newScale = Vector3.Max(newScale, initialScale);
                newScale = Vector3.Min(newScale, Vector3.one * maxScale);

                transform.localScale = newScale;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.touchCount == 2)
        {
            isScaling = true;
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            initialDistance = Vector2.Distance(touch1.position, touch2.position);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Input.touchCount < 2)
        {
            isScaling = false;
        }
    }
}
