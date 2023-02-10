using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public Root[] trees;
    public UIManager uiManager;
    public bool CheckIfValidMove(int index1, int index2)
    {
        //check whether the heart can be added
        if (trees[index1].GetCurrentGrowthCycle() - trees[index2].GetCurrentGrowthCycle() <= 0)
        {
            return true;
        }

        return false;
    }

    private void Update()
    {
        CheckForGameOver();
    }

    void CheckForGameOver()
    {
        if (uiManager.IsGameOver)
            return;
        // check if one of the trees died
        if (trees[0].IsDead() || trees[1].IsDead())
        {
            //game over trees dead
            Debug.Log("game over trees dead");
            uiManager.GameOverNegative();
            uiManager.audioManager.PlayPlayerDeadSound();
        }
        //check if game is completed
        else if (trees[0].IsGrowthComplete() && trees[1].IsGrowthComplete())
        {
            //game over growth completed
            Debug.Log("game over growth completed");
            uiManager.GameOverPositive();
        }

    }
}
