using UnityEngine;

public class RemoveOnWeb : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
#if UNITY_WEBGL
        gameObject.SetActive(false);
#endif
    }

   
}
