using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public Transform carTransform;    // Car's transform to follow
          // Offset to maintain relative to the car

    void LateUpdate()
    {
        // Update light position to follow car
        transform.position = carTransform.position +  new Vector3(-6.2f , carTransform.position.y + 100f , 14.2f);

        // Optionally, align the light's rotation with the car's forward direction
        transform.rotation = Quaternion.LookRotation(carTransform.forward);
    }
}
