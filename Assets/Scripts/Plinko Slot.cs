using UnityEngine;

public class PlinkoSlot : MonoBehaviour
{
    public int scoreGiven = 100;

    public float removeDelay = 2.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        mr.enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        PlinkoDisk pd = other.gameObject.GetComponentInParent<PlinkoDisk>();
        if (pd)
        {
            Debug.Log("Earned " + this.scoreGiven + " points");

            PlinkoManager.instance.AddScore(scoreGiven);

            Destroy(pd.gameObject, removeDelay);

        }
    }
}
