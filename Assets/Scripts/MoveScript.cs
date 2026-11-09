using UnityEngine;
using UnityEngine.Rendering;

public class MoveScript : MonoBehaviour
{

    public Vector3 moveDirectionRate = Vector3.zero;
    //Units per second

  
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 location = gameObject.transform.position;
        
        location += moveDirectionRate * Time.deltaTime;

        gameObject.transform.position = location;

          
    }
}
