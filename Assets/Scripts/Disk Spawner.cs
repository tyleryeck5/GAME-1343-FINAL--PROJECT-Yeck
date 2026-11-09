using UnityEngine;
using UnityEngine.InputSystem;

public class DiskSpawner : MonoBehaviour
{
    public GameObject diskPrefab;

    // Update is called once per frame
    void Update()
    {
        Keyboard kb = Keyboard.current;

        if (kb == null)
        { return; }

        if (kb.spaceKey.wasPressedThisFrame)
        { Instantiate (diskPrefab, gameObject.transform.position, gameObject.transform.rotation); }
    }
}
