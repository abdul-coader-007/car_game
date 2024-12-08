using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // public FuelSystem fuelSystem;
    float Force = 100f;
    
    float steeringAngle = 30f;
    float brakeForce = 3000f;
    float VercticalMove;
    float HorizontalMove;
    public WheelCollider FRWcollider;
    public WheelCollider FLWcollider;
    public WheelCollider RRWcollider;
    public WheelCollider RLWcollider;
    public Transform FRWTransform;
    public Transform FLWTransform;
    public Transform RRWTransform;
    public Transform RLWTransform;

    public Transform carCenterOfMassTransform;
    public Rigidbody rigidbodyCar;

    void Start(){
        rigidbodyCar.centerOfMass = carCenterOfMassTransform.localPosition;
    }
    void FixedUpdate()
    {
        MotorForce();
        updateWheel();
        GetInput();
        Steering();
        PowerSteering();
        Brakes();
    }
    void MotorForce (){
        RRWcollider.motorTorque = Force * VercticalMove;
        RLWcollider.motorTorque = Force * VercticalMove;
    }
    void updateWheel (){
        rotateWheel(FRWcollider , FRWTransform);
        rotateWheel(FLWcollider , FLWTransform);
        rotateWheel(RRWcollider , RRWTransform);
        rotateWheel(RLWcollider , RLWTransform);

    }
    void rotateWheel (WheelCollider wheelCollider, Transform transform){
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
    void GetInput(){
        VercticalMove = Input.GetAxis("Vertical");
        HorizontalMove = Input.GetAxis("Horizontal");
    }

    void Steering(){
        FRWcollider.steerAngle = steeringAngle * HorizontalMove;
        FLWcollider.steerAngle = steeringAngle * HorizontalMove;

        
    }

    void PowerSteering() {
        if(HorizontalMove == 0){
            transform.rotation = Quaternion.Slerp(transform.rotation , Quaternion.Euler(0,0,0) , Time.deltaTime );
        }
    }
    void Brakes(){
        if (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S)){
            FRWcollider.brakeTorque = brakeForce; 
            FLWcollider.brakeTorque = brakeForce; 
            RRWcollider.brakeTorque = brakeForce; 
            RLWcollider.brakeTorque = brakeForce;
        }
        else{
            FRWcollider.brakeTorque = 0f; 
            FLWcollider.brakeTorque = 0f; 
            RRWcollider.brakeTorque = 0f; 
            RLWcollider.brakeTorque = 0f;
        } 
    }
}
