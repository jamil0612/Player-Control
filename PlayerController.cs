using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 100f;
    public float horizontalInput;
    public float forwardInput;

    // Inertia settings
    public float decelerationRate = 5f;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (forwardInput != 0)
        {
            currentSpeed = speed * forwardInput;
        }
        else
        {
            // Gradually reduce the current speed to zero
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, decelerationRate * Time.deltaTime);
        }

        // Move the vehicle forward with the current speed
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

        // Rotate the vehicle
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
