using UnityEngine;

public class PlinkoDisk : MonoBehaviour
{
    public float lifetime = 10;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
