using UnityEngine;

public class CombatController : MonoBehaviour
{
    public int inputNumber = 0;

    public int playerNumber = 1;

    public float moveSpeed = 5;

    public float rotateRate = 180;

    public bool Fire1IsEnabled = true;

    public bool Fire2IsEnabled = true;

    public AudioClip clip_BAP;

    public AudioClip clip_PEW;

    public float pitchMin = .5f;

    public float pitchMax = 1.0f;

    public int kills = 0;

    public int deaths = 0;

    public float KDRatio = 0;

    public GameObject deathDecalPrefab;

    public GameObject RayCastHitPrefab;

    public GameObject projectilePrefab;

    public Transform firingPoint;

    public LaserControl laserControl;

    public float RayDistance = 50f;

    public Color DebugRayColor = Color.blue;

    InputData input;

    Rigidbody rb;

    AudioSource source;

    Vector3 startingLocation;
    Quaternion startingRotation;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        source = gameObject.AddComponent<AudioSource>();

        startingLocation = gameObject.transform.position;

        startingRotation = gameObject.transform.rotation;
    }


    void Update()
    {
        input = InputPoller.reference.GetInput(inputNumber);

        DrawDebugLine();

        MovePlayer(input.leftStick.y);

        RotatePlayer(input.leftStick.x);

        if (input.buttonNorth && Fire1IsEnabled)
        {
            Fire1();
        }

        if (input.buttonEast && Fire2IsEnabled)
        {
            Fire2();
        }
    }

    public void DrawDebugLine()
    {
        Vector3 originPoint = firingPoint.transform.position;
        Vector3 destinationPoint = (firingPoint.transform.forward * RayDistance);

        Debug.DrawRay(originPoint, destinationPoint, DebugRayColor);
    }
    void MovePlayer(float value)
    {
        if (!rb)
        {
            Debug.LogError(gameObject.name + " has no rigid body, cannot move.");
            
            return;
        }
        rb.linearVelocity = value * moveSpeed * gameObject.transform.forward;
    }

    void RotatePlayer(float value)
    {
        gameObject.transform.Rotate(Time.deltaTime * value * rotateRate * Vector2.up);
    }
    public void Fire1()
    {
        //Debug.Log("Fire1");
        SetSoundRandomPitch();

        source.PlayOneShot(clip_BAP);

        FireProjectile();
    }

    public void FireProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
        
        CombatProjectile cp = newProjectile.GetComponent<CombatProjectile>();
        
        cp.owner = this;
    }
    public void Fire2()
    {
        SetSoundRandomPitch();
        
        source.PlayOneShot(clip_PEW);
        
        PerformRaycast();
        //Debug.Log("Fire2");
    }

    public void PerformRaycast()
    {
        RaycastHit hit;

        bool hasHit = Physics.Raycast(firingPoint.position, firingPoint.forward, out hit, RayDistance);

        if (hasHit)
        {
            Debug.Log("Raycast hit on" + hit.collider.gameObject.name);

            Instantiate(RayCastHitPrefab, hit.point, Quaternion.identity);

            laserControl.FireLaser(hit.distance);

            CombatController cc = hit.collider.gameObject.GetComponentInParent<CombatController>();
            if(cc)
            {
                Debug.Log("Raycast hit on player" + cc.gameObject.name);
                cc.AddDeath();
                cc.Reset();
                this.AddKill();
            }

            CombatProjectile cp = hit.collider.gameObject.GetComponentInParent<CombatProjectile>();

            if(cp)
            {
                cp.RemoveFromWorld(false);
            }
        }
    }

    public void SetSoundRandomPitch()
    {
        source.pitch = Random.Range(pitchMin, pitchMax);
    }


    public void Reset()
    {
        Instantiate(deathDecalPrefab, gameObject.transform.position, gameObject.transform.rotation);

        gameObject.transform.position = startingLocation;
        
        gameObject.transform.rotation = startingRotation;
        
        rb.angularVelocity = Vector3.zero;
        
        rb.linearVelocity = Vector3.zero;
    }

    public void AddKill()
    {
        kills++;

        CalculateKDRatio();

        CombatManager.instance.AddScore(playerNumber);
    }

    public void AddDeath()
    {
        deaths++;

        CalculateKDRatio();
    }

    public void CalculateKDRatio()
    {
        if (deaths == 0)
        {
            KDRatio = kills;
            return;
        }

        KDRatio = (float)kills / (float)deaths;
    }
}
