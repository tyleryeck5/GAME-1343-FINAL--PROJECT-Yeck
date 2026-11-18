using UnityEngine;

public class Arrest : MonoBehaviour

    
{
    Rigidbody rb;
    Vector3 startingLocation;
    Quaternion startingRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingLocation = gameObject.transform.position;

        startingRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        //Instantiate(gameObject.transform.position, gameObject.transform.rotation);

        gameObject.transform.position = startingLocation;

        gameObject.transform.rotation = startingRotation;

        rb.angularVelocity = Vector3.zero;

        rb.linearVelocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
