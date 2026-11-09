using UnityEngine;
using UnityEngine.InputSystem;
public class InputTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput(); 
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
        if (kb.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Space Bar");
        }
        
        if (kb.wKey.wasPressedThisFrame)
        {
            Debug.Log("W");
        }

        if (kb.dKey.wasPressedThisFrame)
        {
            Debug.Log("D");
        }

        if (kb.sKey.wasPressedThisFrame)
        {
            Debug.Log("S");
        }

        if (kb.aKey.wasPressedThisFrame)
        {
            Debug.Log("A");
        }

        if (kb.iKey.wasPressedThisFrame)
        {
            Debug.Log("I");
        }

        if (kb.lKey.wasPressedThisFrame)
        {
            Debug.Log("L");
        }

        if (kb.kKey.wasPressedThisFrame)
        {
            Debug.Log("K");
        }

        if (kb.jKey.wasPressedThisFrame)
        {
            Debug.Log("J");
        }

        if (mouse.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Left Button");
        }

        if (mouse.rightButton.wasPressedThisFrame)
        {
            Debug.Log("Right Button");
        }
    }
}
