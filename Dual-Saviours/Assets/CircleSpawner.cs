using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    //script to visualize great circles

    public float radius = 10f;
    public float rotateAngle = 0f;
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        /*for (int i = 0; i < 360; i += 10)
        {*/
            DrawCircle(radius, 0f, 0f);
        //}
    }

    void DrawCircle(float radius, float cX, float cY)
    {
        //we use the polar coordinate to determine the next points in our circle
        //rcos(0) rsin(0)

        Vector2[] points = new Vector2[360];
        
        for (int i = 0; i < 360; i++)
        {
            points[i] = new Vector2(radius * Mathf.Cos(i * Mathf.Deg2Rad), radius * Mathf.Sin(i * Mathf.Deg2Rad));

            //rotate the vectors if rotation angle is specified
            //rotate along the y axis for now

        }

        Vector3 point1 = Vector3.zero, point2 = Vector3.zero;
        
        for (int i = 1; i < 360; i++)
        {
            if (i == 1)
            {
                point1 = new Vector3(points[i - 1].x, points[i - 1].y, 0f);
            }
            point2 = new Vector3(points[i].x, points[i].y, 0f);
                
            point1 = point2;
        }
    }
}
