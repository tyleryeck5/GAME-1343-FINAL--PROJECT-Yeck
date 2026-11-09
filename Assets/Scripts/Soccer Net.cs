using UnityEngine;

public class SoccerNet : MonoBehaviour
{
    public int teamNumber = 0;
    
    public int score = 0;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Net Found: " + other.gameObject.name);

        SoccerBall sb = other.gameObject.GetComponent<SoccerBall>();
        if (sb)
        {
           
            score++;
            sb.Reset(); 
            
            Debug.Log("Ball Scored! Team " + teamNumber + "@" +score);
        }
    }
}
