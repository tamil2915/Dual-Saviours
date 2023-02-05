using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepAudio : MonoBehaviour
{
    public AudioManager audioManager;
    
    public void PlayFootStep()
    {
        audioManager.PlayFootStep();
    }
}
