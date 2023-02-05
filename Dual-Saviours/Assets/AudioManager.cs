using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public AudioSource secondaryPlayer;

    public void PlayFootStep()
    {
        audioSource.clip = audioClips[0];
        if (!audioSource.isPlaying)
            PlayOneShot();
    }

    public void PlayOneShot()
    {
        audioSource.Play();
    }

    public void PlayHeartSound()
    {
        secondaryPlayer.clip = audioClips[1];

        secondaryPlayer.Play();
    }

    public void PlayTreeGrowSound()
    {
        secondaryPlayer.clip = audioClips[2];
        secondaryPlayer.Play();
    }

    public void PlayGameOverPositiveSound()
    {
        secondaryPlayer.clip = audioClips[3];
        secondaryPlayer.Play();
    }
}
