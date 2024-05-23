using UnityEngine;
using UnityEngine.EventSystems;

public class Pinch2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isScaling;
    private float initialDistance;
    private Vector3 initialScale;
    public float maxScale = 2.0f; // Ajusta este valor según sea necesario

    private Vector2 initialMidPoint;

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
                newScale = Vector3.Min(newScale, initialScale * maxScale);

                // Aplicar la nueva escala
                transform.localScale = newScale;

                // Calcular el nuevo centro de la escala
                Vector2 currentMidPoint = (touch1.position + touch2.position) / 2;
                Vector2 delta = currentMidPoint - initialMidPoint;
                transform.position += (Vector3)delta / GetComponentInParent<Canvas>().scaleFactor; // Ajusta el movimiento según el factor de escala del canvas
                initialMidPoint = currentMidPoint; // Actualiza el punto medio inicial
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
            initialMidPoint = (touch1.position + touch2.position) / 2;
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
