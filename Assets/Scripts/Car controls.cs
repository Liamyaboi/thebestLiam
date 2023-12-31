using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontrols : MonoBehaviour
{
    public float accelerationFactor = 30f;
    public float turnFactor = 3.5f;
    public float driftFactor = 0.95f;
    public float maxSpeed = 20;

    float accelerationInput = 0;    
    float rotationAngle = 0;
    float steeringInput = 0;
    float velocityVsUp = 0;
    
    Rigidbody2D carRigidbody2D;
    
    private void Awake()
    {
        carRigidbody2D = GetComponent <Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();

        killOrthogonalVelocity();

        ApplySteering();
    }

   

    void ApplyEngineForce()
    {

        velocityVsUp = Vector2.Dot(transform.up, carRigidbody2D.velocity);

        if (velocityVsUp > maxSpeed && accelerationInput > 0)
            return;

        if (velocityVsUp < -maxSpeed * 0.5f && accelerationInput < 0) 
            return;

        if (carRigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;


        if (accelerationInput == 0)
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3f, Time.fixedDeltaTime * 3);
        else carRigidbody2D.drag = 0;

        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

     void ApplySteering()
    {
        float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.velocity.magnitude/8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;

        carRigidbody2D.MoveRotation(rotationAngle);
    }
    void killOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot( carRigidbody2D.velocity, transform.right);
        
        carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
