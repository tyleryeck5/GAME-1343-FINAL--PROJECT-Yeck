using Unity.VisualScripting;
using UnityEngine;

public class RunnerScript : MonoBehaviour
{
    public GameObject targetA;
    public GameObject targetB;
    GameObject currentTarget;
    bool IsMovingtoA = true;
    public float movementSpeed = 5;
    public float withinRangeofPoint = 0.75f;
    Vector3 moveDirection = Vector3.zero;
    public bool hasDynamicDirection = false;

    void Start()
    {
        currentTarget = targetA;
        IsMovingtoA = true;
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
        if (IsMovingtoA)
        {
            currentTarget = targetB;
            IsMovingtoA = false;
        }
        else
        {
            currentTarget = targetA;
            IsMovingtoA = true;
        }
    }

    public void UpdateMoveDirection()
    { Vector3 directionVector = currentTarget.transform.position - gameObject.transform.position;
        moveDirection = directionVector.normalized;
        gameObject.transform.forward = directionVector;
    }
}
