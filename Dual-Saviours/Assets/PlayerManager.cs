using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player player1;
    public Player player2;

    public AudioManager audioManager;

    private void Update()
    {
        CheckForHeartDonation();
    }

    void CheckForHeartDonation()
    {
        if (Vector3.Distance(player1.transform.position, player2.transform.position) <= 6f)
        {
            player1.PutHeart();
            player2.PutHeart();
            audioManager.PlayHeartSound();
        }
    }
}
