using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public int zoomOut;
    public float smoothOut;
    public float normal;
    public Camera cameraZoom;
    public CameraTracking cameraTracking;
    public Transform cameraFocus;
    public Transform playerFocus;

    // Start is called before the first frame update
    void Start()
    {
        normal = cameraZoom.GetComponent<Camera>().fieldOfView;
        playerFocus = cameraTracking.GetComponent<CameraTracking>().trackingTarget;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraZoom.fieldOfView = Mathf.Lerp(cameraZoom.GetComponent<Camera>().fieldOfView, zoomOut, Time.deltaTime * smoothOut);
            Debug.Log("Zooming out");
            cameraTracking.GetComponent<CameraTracking>().isZoomedOout = true;
            cameraTracking.GetComponent<CameraTracking>().trackingTarget = cameraFocus;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraZoom.fieldOfView = Mathf.Lerp(cameraZoom.GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smoothOut);
            Debug.Log("Zooming Back In");
            cameraTracking.GetComponent<CameraTracking>().isZoomedOout = false;
            cameraTracking.GetComponent<CameraTracking>().trackingTarget = playerFocus;
        }
    }
}
