using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    // UI Elements
    [SerializeField] Transform[] lanes;

    [SerializeField] GameObject FuelObject;

    [SerializeField] Transform carTransform;


    void Start()
    {
        
        InvokeRepeating("FuelSpawner", 0f, 5f);
    }


    void FuelSpawner(){
// Random indexes for lanes and vehicles
        int laneIndex = Random.Range(0, lanes.Length - 1);

        // Spawn vehicle at the selected lane position
        GameObject newVehicle = Instantiate(FuelObject, lanes[laneIndex].position, Quaternion.identity);

         // Assign the traffic tag to help in identifying traffic vehicles later
        newVehicle.tag = "FuelPickup";  // Make sure your vehicle prefab has the tag "Traffic" set in Unity
    }



    void OnTriggerEnter(Collider other)
    {
        // Check if player collides with a fuel pickup
        if (other.CompareTag("FuelPickup"))
        {
            Destroy(other.gameObject); // Destroy the pickup object
        }
    }

}
