using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;

public class PreciseGeolocationARController : MonoBehaviour
{
    public Transform character; // El transform del personaje que quieres mover
    public TMP_Text statusText; // Texto UI para mostrar el estado de la geolocalización
    public float updateInterval = 1.0f; // Intervalo de actualización de la posición en segundos
    public int filterWindowSize = 5; // Tamaño de la ventana de filtro para suavizar la posición

    private ARAnchorManager arAnchorManager;
    private bool isLocationServiceRunning = false;
    private Queue<Vector3> locationQueue = new Queue<Vector3>();
    private float lastUpdateTime;
    private ARAnchor currentAnchor;

    void Start()
    {
        arAnchorManager = GetComponent<ARAnchorManager>();
        StartCoroutine(StartLocationService());
    }


    IEnumerator StartLocationService()
    {
        // Verifica si el dispositivo tiene habilitados los servicios de ubicación
        if (!Input.location.isEnabledByUser)
        {
            statusText.text = "Los servicios de ubicación están deshabilitados";
            yield break;
        }

        // Comienza el servicio de ubicación con la máxima precisión
        Input.location.Start(0.5f, 0.5f); // Primera precisión, segunda distancia mínima para obtener actualizaciones

        // Espera hasta que el servicio de ubicación inicie
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Si el servicio de ubicación falla en iniciar
        if (maxWait < 1)
        {
            statusText.text = "Error: El servicio de ubicación tardó demasiado en iniciar";
            yield break;
        }

        // Si el servicio de ubicación está denegado por el usuario
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            statusText.text = "Error: No se pudo determinar la ubicación del dispositivo";
            yield break;
        }
        else
        {
            // El servicio de ubicación inició correctamente
            statusText.text = "Servicio de ubicación iniciado correctamente";
            isLocationServiceRunning = true;
        }
    }

    [System.Obsolete]
    void Update()
    {
        if (isLocationServiceRunning && Time.time - lastUpdateTime >= updateInterval)
        {
            // Obtén la última ubicación
            LocationInfo location = Input.location.lastData;
            statusText.text = $"Latitud: {location.latitude} Longitud: {location.longitude} Precisión: {location.horizontalAccuracy}m";

            // Convierte la posición de latitud y longitud a una posición en el espacio de AR
            Vector3 newPosition = new Vector3(location.latitude, 0, location.longitude);
            locationQueue.Enqueue(newPosition);

            // Mantener el tamaño de la ventana de filtro
            if (locationQueue.Count > filterWindowSize)
            {
                locationQueue.Dequeue();
            }

            // Calcula el promedio de la ventana de filtro
            Vector3 averagePosition = Vector3.zero;
            foreach (Vector3 pos in locationQueue)
            {
                averagePosition += pos;
            }
            averagePosition /= locationQueue.Count;

            // Crea o actualiza un ancla en la posición promedio
            if (currentAnchor != null)
            {
                Destroy(currentAnchor.gameObject);
            }

            currentAnchor = arAnchorManager.AddAnchor(new Pose(averagePosition, Quaternion.identity));
            if (currentAnchor != null)
            {
                character.position = currentAnchor.transform.position;
                character.rotation = currentAnchor.transform.rotation;
            }

            lastUpdateTime = Time.time;
        }
    }

    void OnDisable()
    {
        if (isLocationServiceRunning)
        {
            Input.location.Stop(); // Detén el servicio de ubicación cuando no se necesite
        }
    }
}
