using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    //This Script is used to rotate objects over time
    [Header("Object Rotation")]
    [SerializeField]
    [Tooltip("This will change the speed of the rotation on X,Y,Z")]
    private Vector3 rotationVelocity;//the rotation of the object over x,y,z

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVelocity * Time.deltaTime);
    }
}
