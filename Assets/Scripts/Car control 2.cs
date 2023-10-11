using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontrols2 : MonoBehaviour
{
    public float accelerationFactor2 = 30f;
    public float turnFactor2 = 3.5f;
    public float driftFactor2 = 0.95f;
    public float maxSpeed2 = 20;

    float accelerationInput2 = 0;
    float rotationAngle2 = 0;
    float steeringInput2 = 0;
    float velocityVsUp2 = 0;

    Rigidbody2D carRigidbody2D;

    private void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        ApplyEngineForce();

        killOrthogonalVelocity();

        ApplySteering();
    }

    void ApplyEngineForce()
    {

        velocityVsUp2 = Vector2.Dot(transform.up, carRigidbody2D.velocity);

        if (velocityVsUp2 > maxSpeed2 && accelerationInput2 > 0)
            return;

        if (velocityVsUp2 < -maxSpeed2 * 0.5f && accelerationInput2 < 0)
            return;

        if (carRigidbody2D.velocity.sqrMagnitude > maxSpeed2 * maxSpeed2 && accelerationInput2 > 0)
            return;


        if (accelerationInput2 == 0)
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3f, Time.fixedDeltaTime * 3);
        else carRigidbody2D.drag = 0;




        Vector2 engineForceVector = transform.up * accelerationInput2 * accelerationFactor2;

        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        rotationAngle2 -= steeringInput2 * turnFactor2 * minSpeedBeforeAllowTurningFactor;

        carRigidbody2D.MoveRotation(rotationAngle2);
    }
    void killOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

        carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor2;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput2 = inputVector.x;
        accelerationInput2 = inputVector.y;

    }


}

