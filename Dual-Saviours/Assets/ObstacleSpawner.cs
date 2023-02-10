using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            Vector3 pos = Random.onUnitSphere * 75f;

            if(pos.x == 0 && pos.y == 1 ||
                pos.x == 0 && pos.y == -1)
            {
                continue;
            }

            float scale = Random.Range(20, 50);

            
            GameObject obj = Instantiate(obstacle, pos, Quaternion.identity, this.transform);
            obj.transform.localScale = Vector3.one * scale;

            obj.transform.up = obj.transform.position - Vector3.zero;
        }
    }
}
