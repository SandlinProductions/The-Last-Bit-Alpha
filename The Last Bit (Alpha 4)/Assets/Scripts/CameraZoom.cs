using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public int zoom = 15;
    public int zoomOut = 20;
    public float normal;
    public float smooth = 1;
    public float smoothOut = 5;

    private bool isZoomed = false;
    private bool isZoomedOut = false;

    public CameraTracking cameraTracking;

    private void Start()
    {
       normal = GetComponent<Camera>().fieldOfView;
    }

    private void Update()
    {
        if (cameraTracking.GetComponent<CameraTracking>().isZoomedOout == false)
        {


            if (Input.GetButton("Jump"))
            {
                isZoomed = !isZoomed;
            }
            if (isZoomed)
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
            }
            else
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
            }
            if (Input.GetButtonDown("GamePad"))
            {
                isZoomedOut = !isZoomedOut;
            }
            if (isZoomedOut)
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoomOut, Time.deltaTime * smoothOut);

            }
            else
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smoothOut);
            }
        }
    }
}