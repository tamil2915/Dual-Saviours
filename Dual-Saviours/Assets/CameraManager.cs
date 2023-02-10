using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera[] cameras;

    public void GameOver()
    {

        for (int i =1; i<cameras.Length; i++)
        {
            cameras[i].enabled = false ;
        }
    }
}
