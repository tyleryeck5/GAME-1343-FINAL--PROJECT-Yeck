using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{

    public int inputNumber = 0;

    public float moveSpeed = 5;

    public float rotateRate = 180;
    
    InputData input;

    Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        input = InputPoller.reference.GetInput(inputNumber);

        MovePlayer(input.leftStick.y);
        RotatePlayer(input.leftStick.x);
    }

    void MovePlayer(float value)
    {
        if (!rb)
        {
            Debug.LogError(gameObject.name + " has no rigid body, cannot move.");
            return;
        }
        rb.linearVelocity =  value  * moveSpeed * gameObject.transform.forward;
    }

    void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(Time.deltaTime * value * rotateRate * Vector2.up);
    }
}
