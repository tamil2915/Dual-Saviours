using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsVelocity : MonoBehaviour
{
    Rigidbody rb;

    public Vector3 forwardVector = Vector3.forward;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void SetRotation(Vector3 from, Vector3 to)
    {
       // transform.forward = (from - to).normalized;
    }
}
