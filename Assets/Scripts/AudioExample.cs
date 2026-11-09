using UnityEngine;
using UnityEngine.InputSystem;

public class AudioExample : MonoBehaviour {

    public GameObject MusicGameObject;

    public AudioClip Bap;

    public AudioClip Pew;

    AudioSource source;

    AudioSource musicSource;

    // Use this for initialization
    void Start () {
        source = gameObject.AddComponent<AudioSource>();

        musicSource = MusicGameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Keyboard kb = Keyboard.current;

        Mouse mouse = Mouse.current;

        if ((kb == null) || (mouse == null))
        {
            Debug.Log("No keyboard or mouse");
            
            return;
        }

        // Play One Shot Sound
        if (mouse.leftButton.wasPressedThisFrame)
        { 
            source.PlayOneShot(Bap);
           
            Debug.Log("Bap");
        }

        // Play One Shot Sound
        if (mouse.rightButton.wasPressedThisFrame)
        {
            source.PlayOneShot(Pew);
            
            Debug.Log("Pew");
        }

        // Toggle Spacial Blend
        if (kb.spaceKey.wasPressedThisFrame)
        {
            ToggleSpacialBlend(); 
        }

        
    }

    public void ToggleSpacialBlend()
    {
        if (musicSource.spatialBlend == 1 )
        {
            musicSource.spatialBlend = 0;
            
            Debug.Log("Spatical Blend = 0 (2d)"); 
        } 
        
        else
        {
            musicSource.spatialBlend = 1;
            
            Debug.Log("Spatical Blend = 1 (3d)");
        }
    }
}
