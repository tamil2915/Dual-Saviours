using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionStorer : MonoBehaviour
{
    public Vector3 previousPosition;
    public Vector3 currentPosition;

    bool isFirstTime = true;

    public RotateTowardsVelocity rotator;

    private void Start()
    {
        previousPosition = transform.position;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;

        rotator.RotateThePlayer((currentPosition - previousPosition));

        previousPosition = transform.position;
    }
    public Vector3 GetCurrentPosition()
    {
        return previousPosition;
    }

    public Vector3 GetPreviousPosition()
    {
        return previousPosition;
    }
}
