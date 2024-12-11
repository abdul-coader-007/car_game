using UnityEngine;

public class LaneMovement : MonoBehaviour
{
    public Transform carTransform;

    public float spawnOffset = 80f;
    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
         // Update lane's position dynamically ahead of the car
        transform.position = new Vector3(
            -10 , 
            0 ,  // Keep current lane's Y position consistent
            carTransform.position.z + spawnOffset
        );
    }
}
