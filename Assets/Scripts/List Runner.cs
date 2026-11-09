using UnityEngine;
using System.Collections.Generic;

public class ListRunner : MonoBehaviour
{
    public List<GameObject> pathList;

    public int pathListIndex = 0;

    GameObject currentTarget;
    
    public float movementSpeed = 5;

    public float withinRangeofPoint = 0.75f;
    
    Vector3 moveDirection = Vector3.zero;
    
    public bool hasDynamicDirection = false;

    void Start()
    {
        pathListIndex = 0;
        
        currentTarget = pathList[pathListIndex];
        
        UpdateMoveDirection();
    }


    void Update()
    {
        if (hasDynamicDirection)

        { UpdateMoveDirection(); }
        
        Vector3 location = gameObject.transform.position;
        
        location += moveDirection * movementSpeed * Time.deltaTime;
        
        gameObject.transform.position = location;
        
        if (IsClosetoTarget())
        {
            NextTarget();
           
            UpdateMoveDirection();
        }
    }

    public float GetDistanceTo(GameObject other)
    {
        Vector3 distanceVector = other.transform.position - gameObject.transform.position;
       
        return distanceVector.magnitude;
    }

    public bool IsClosetoTarget()
    {
        if (GetDistanceTo(currentTarget) <= withinRangeofPoint)
        
        { return true; }
        
        return false;
    }

    void NextTarget()
    {
       pathListIndex++;
        
        if (pathListIndex >= pathList.Count)
        
        { pathListIndex = 0; }
        
        currentTarget = pathList[pathListIndex];
    }

    public void UpdateMoveDirection()
    {
        Vector3 directionVector = currentTarget.transform.position - gameObject.transform.position;
       
        moveDirection = directionVector.normalized;
        
        gameObject.transform.forward = directionVector;
    }

   
}
