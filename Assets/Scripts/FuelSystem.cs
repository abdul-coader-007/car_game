using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    // UI Elements
    [SerializeField] private Transform[] lanes;

    [SerializeField] private GameObject FuelObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float rotationSpeed = 50f;  // Speed of the rotation motion

    [SerializeField] private int fuelsPickedUp = 0;

    // Reference to the car (make sure you assign it in the Inspector or find it in Start())
    [SerializeField] private Transform carTransform;


    // Fuel-related variables
    private float fuelLevel = 100f; // Starting fuel level
    private float maxFuelLevel = 100f; // Maximum fuel capacity
    private float fuelConsumptionRate = 5f; // Rate of fuel consumption per second
    private float fuelIncreaseAmount = 20f; // Fuel added per pickup



    void Start()
    {
        InvokeRepeating("fuelSpawner", 0f, 10f);
        
    }


    void fuelSpawner(){
// Random indexes for lanes and vehicles
        int laneIndex = Random.Range(0, 3);

        // Spawn vehicle at the selected lane position
        GameObject newfuel = Instantiate(FuelObject, lanes[laneIndex].position, Quaternion.identity);

         // Assign the traffic tag to help in identifying traffic vehicles later
        newfuel.tag = "FuelPickup";  // Make sure your vehicle prefab has the tag "Traffic" set in Unity
    }




    void missingFuelDestroyer() {
        // Iterate through all traffic vehicles and check if they have passed the car
        foreach (GameObject oilContainer in GameObject.FindGameObjectsWithTag("FuelPickup"))
        {
            // Check if vehicle passed the car's position        
            if(oilContainer.transform.position.y < -50){
                Destroy(oilContainer);
            }
        }
    }

    void fuelFloater(){
        foreach (GameObject oilContainer in GameObject.FindGameObjectsWithTag("FuelPickup"))
        {

        // Apply rotation for a floating effect
        oilContainer.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

    }

    void ConsumeFuel()
    {
        if (fuelLevel > 0)
        {
            // Decrease fuel level smoothly over time
            fuelLevel -= fuelConsumptionRate * Time.deltaTime;
            
        }
        else
        {
            // Handle what happens when fuel runs out
            Debug.Log("Out of Fuel! Game Over!");
        }
    }

    

    void Update(){
        missingFuelDestroyer() ;
        fuelFloater();
        CheckFuelPickup();
    }


    void CheckFuelPickup(){
    
    // Iterate through all active fuel objects
    foreach (GameObject fuel in GameObject.FindGameObjectsWithTag("FuelPickup")){
        // Calculate distance between car and fuel
        float distance = Vector3.Distance(carTransform.position, fuel.transform.position);

        // If distance is within a pickup range, consider it collected
        if (distance < 2f){ // Adjust the threshold as needed

            fuelsPickedUp++;
            fuelLevel = Mathf.Min(fuelLevel + fuelIncreaseAmount, maxFuelLevel); // Add fuel but cap at maxFuelLevel
                // fuelSlider.value = Mathf.Lerp(fuelSlider.value, fuelLevel, Time.deltaTime * 5); // Smooth transition
               
            Destroy(fuel); // Remove the fuel pickup
        }
    }
    }

    public int getFuelPickedUp(){
        return fuelsPickedUp;
    }

    public float getFuelLevel(){
        return fuelLevel;
    }



}
