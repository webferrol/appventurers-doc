using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARGeolocationManager : MonoBehaviour {
    public ARAnchorManager anchorManager;
    public GameObject arObjectPrefab;
    private ARAnchor arAnchor;
    private Vector3 currentPosition;

    void Start() {
        Input.location.Start();
    }

    void Update() {
        if (Input.location.status == LocationServiceStatus.Running) {
            Vector3 gpsPosition = GetGPSPosition(Input.location.lastData);
            currentPosition = SmoothGPSData(currentPosition, gpsPosition);

            if (arAnchor == null) {
                Pose pose = new Pose(currentPosition, Quaternion.identity);
                arAnchor = anchorManager.AddAnchor(pose);
                Instantiate(arObjectPrefab, pose.position, pose.rotation, arAnchor.transform);
            } else {
                arAnchor.transform.position = currentPosition;
            }
        }
    }

    Vector3 GetGPSPosition(LocationInfo locationInfo) {
        // Convierte los datos de GPS a una posición en el mundo
        return new Vector3(locationInfo.latitude, 0, locationInfo.longitude);
    }

    Vector3 SmoothGPSData(Vector3 currentPosition, Vector3 newGPSData, float smoothingFactor = 0.1f) {
        return Vector3.Lerp(currentPosition, newGPSData, smoothingFactor);
    }
}
