using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform carPosition;
    public Transform otherCityPosition;

    public float cityLength = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame

    void changeCity() {
        if(carPosition.position.z > transform.position.z + 100f ){
            transform.position= new Vector3(0,0,otherCityPosition.position.z + cityLength) ;
        }
    }
    void Update()
    {
        changeCity();
        
    }
}
