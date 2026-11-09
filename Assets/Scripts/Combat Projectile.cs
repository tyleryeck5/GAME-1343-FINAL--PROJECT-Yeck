using UnityEngine;

public class CombatProjectile : MonoBehaviour
{

    public float moveSpeed = 5f;

    public float lifeTime = 5f;
    
    public float damageValue = 50;
    
    public GameObject deathDecalPrefab;

    public CombatController owner;

    Rigidbody rb;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);

        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = gameObject.transform.forward * moveSpeed;

    }

    private void OnTriggerEnter(Collider other)
    {
        CombatProjectile pb = other.gameObject.GetComponentInParent<CombatProjectile>();

        if(pb)
        {
            pb.RemoveFromWorld(false);

            this.RemoveFromWorld();
        }

        CombatController cc = other.gameObject.GetComponentInParent<CombatController>();
        if(cc)
        {
            cc.AddDeath();

            cc.Reset();
            
            owner.AddKill();
            
            this.RemoveFromWorld();
            
            return;
        }
        this.RemoveFromWorld();
    }

    public void RemoveFromWorld(bool DropDecal = true)
    {
        if(DropDecal)
        {
            Instantiate(deathDecalPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }

        Destroy(gameObject);
    }
}
