using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI speedText ;
    [SerializeField] private CarController carController;

    [SerializeField] private FuelSystem fuelSystem;

    [SerializeField] private TextMeshProUGUI fuelCount;

    // UI Elements
    [SerializeField] private Slider fuelSlider;

    // Fuel-related variables
    private float fuelLevel = 100f; // Starting fuel level
    private float maxFuelLevel = 100f; // Maximum fuel capacity
    private float fuelConsumptionRate = 5f; // Rate of fuel consumption per second
    private float fuelIncreaseAmount = 20f; // Fuel added per pickup

     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = carController.getSpeed().ToString() + "MK/H";
        fuelCount.text = fuelSystem.getFuelPickedUp().ToString() ;
        fuelSlider.value = fuelSystem.getFuelLevel();
    }
}
