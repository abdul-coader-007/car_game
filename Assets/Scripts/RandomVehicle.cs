using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVehicle : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    void Start(){

    }

    void Update(){
        transform.Translate(0,0, speed * Time.deltaTime);
    }
}
