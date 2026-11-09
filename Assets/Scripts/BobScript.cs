using UnityEngine;


public class BobScript : MonoBehaviour
{
    public float bobHeight = 1;

    public float bobSpeed = 1;

    Vector3 StartingLocation;

    float ceiling = 0;
    float floor = 0;

    float direction = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartingLocation = gameObject.transform.position;
        floor = StartingLocation.y;
        ceiling = StartingLocation.y + bobHeight;
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 location = gameObject.transform.position;

        location.y += direction * bobSpeed * Time.deltaTime;

        if (location.y >= ceiling)
        {
            direction = -1; //lowers down
            location.y = ceiling;
        }

        if (location.y <= floor)
        {
            direction = 1; //rises up
            location.y = floor;
        }

        gameObject.transform.position = location;
    }
}
