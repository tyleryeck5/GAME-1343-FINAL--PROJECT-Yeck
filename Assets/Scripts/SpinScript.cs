using UnityEngine;

public class SpinScript : MonoBehaviour
{

    public Vector3 spinrate = Vector3.zero;
    /// <summary>
    /// units per second
    /// </summary>




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      gameObject.transform.Rotate(spinrate * Time.deltaTime);  
    }
}
