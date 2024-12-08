using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    // UI Elements
    public Slider fuelSlider; // Drag your FuelMeterSlider here in the Inspector

    // Fuel Variables
    public float maxFuel = 100f; // Maximum fuel capacity
    public float currentFuel; // Current fuel amount
    public float fuelConsumptionRate ; // Fuel consumption per second

    void Start()
    {
        // Initialize fuel at max capacity
        currentFuel = maxFuel;
        UpdateFuelUI();
    }

    void Update()
    {
        // Decrease fuel over time
        if (currentFuel > 0)
        {
            ConsumeFuel();
        }
    }

    void ConsumeFuel()
    {
        currentFuel -= fuelConsumptionRate * Time.deltaTime; // Reduce fuel
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel); // Ensure fuel doesn't go below 0
        UpdateFuelUI();
    }

    void UpdateFuelUI()
    {
        // Update the UI slider value (normalize between 0 and 1)
        if (fuelSlider != null)
        {
            fuelSlider.value = currentFuel / maxFuel;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if player collides with a fuel pickup
        if (other.CompareTag("FuelPickup"))
        {
            Refuel(20f); // Refuel by 20 units
            Destroy(other.gameObject); // Destroy the pickup object
        }
    }

    public void Refuel(float amount)
    {
        currentFuel += amount; // Add fuel
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel); // Ensure it doesn't exceed maxFuel
        UpdateFuelUI();
    }
}
