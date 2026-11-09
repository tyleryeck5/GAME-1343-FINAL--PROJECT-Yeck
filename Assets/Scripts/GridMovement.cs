using UnityEngine;
using UnityEngine.InputSystem;
public class GridMovement : MonoBehaviour
{
    public float gridsize = 0.25f;

    bool forward = false; //I
    bool backward = false; //K
    bool right = false; //L
    bool left = false; //J

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        Vector3 location = gameObject.transform.position;

        if (forward)
        {
            location += (Vector3.forward * gridsize);
            gameObject.transform.forward = Vector3.forward;
        }

        if (backward)
        {
            location += (Vector3.back * gridsize);
            gameObject.transform.forward = Vector3.back;
        }

        if (right)
        {
            location += (Vector3.right * gridsize);
            gameObject.transform.forward = Vector3.right;
        }

        if (left)
        {
            location += (Vector3.left * gridsize);
            gameObject.transform.forward = Vector3.left;
        }

        gameObject.transform.position = location;
    }
    public void GetInput()
    {
        Keyboard kb = Keyboard.current;
        Mouse mouse = Mouse.current;

        if ( (kb == null) || (mouse == null) )
        {
            Debug.LogWarning("No Keyboard or Mouse Found");
            return;
        }
        forward = kb.iKey.wasPressedThisFrame;
        backward = kb.kKey.wasPressedThisFrame;
        right = kb.lKey.wasPressedThisFrame;
        left = kb.jKey.wasPressedThisFrame;

    }
}
