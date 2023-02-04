using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 origin = Vector3.zero;

    public float movementSpeed = 10f;

    public Vector2 moveDir = Vector2.zero;
    
    public float yScale = 10.5f;

    public void GetPlayerInput(Vector2 direction)
    {
        moveDir = direction;
    }

    private void Start()
    {
        moveDir.Normalize();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        AlignWithPlanet();
        MovePlayer(moveDir);
    }
    
    void AlignWithPlanet()
    {
        transform.up = GetElapsedRotation(transform.position);

        Debug.Log(transform.localRotation);
    }

    Vector3 GetElapsedRotation(Vector3 pos)
    {
        Vector3 elapsedRotation = pos - origin;
        return elapsedRotation.normalized;
    }

    void MovePlayer(Vector2 direction)
    {
        //we need to get the tangent vector of player's current position
        //then we need to move the player along the tangent

        Vector3 dir = new Vector3(direction.x, 0f, direction.y);

        dir = transform.localRotation * dir;

        dir = dir.normalized;
        dir = dir * movementSpeed * Time.fixedDeltaTime;


        transform.position += dir;

        transform.position = GetElapsedRotation( transform.position ) * yScale;
    }
}
