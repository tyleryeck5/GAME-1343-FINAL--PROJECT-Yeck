using UnityEngine;

public class SoccerBall : MonoBehaviour
{
   Vector3 StartingLocation = Vector3.zero;
    Quaternion StartingRotation = Quaternion.identity;
    
    Rigidbody rb;
    
    void Start()
    {
        StartingLocation = gameObject.transform.position;
        StartingRotation = gameObject.transform.rotation;
        rb = gameObject.GetComponent<Rigidbody>();


    }

    

    public void Reset()
    {
        gameObject.transform.position = StartingLocation;
        gameObject.transform.rotation = StartingRotation;
        rb.linearVelocity = Vector3.zero;
        rb .angularVelocity = Vector3.zero;

    }
}
