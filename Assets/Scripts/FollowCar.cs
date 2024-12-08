using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public Transform carTransform;
    public Transform cameraTransform;
    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.LookAt(carTransform);
        transform.position = cameraTransform.position;
    }
}
