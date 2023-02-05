using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public int treeIndex;
    public int loverIndex;

    private const int _noOfGrowths = 5;

    public float cycleTime = 10f; // duration for each growth or death cycle

    int _currentGrowthCycle = 3;

    float elapsedTime = 0;

    public TreeManager treeManager;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= cycleTime)
        {
            //check for the currentStatus
            DecrementGrowth();
        }
    }

    public int GetCurrentGrowthCycle()
    {
        return _currentGrowthCycle;
    }

    public void IncrementGrowth() {

        if (treeManager.CheckIfValidMove(treeIndex, loverIndex))
        {
            _currentGrowthCycle++;
        }
        else
            return;

        if (_currentGrowthCycle >= _noOfGrowths)
        {
            //Game over game complete
            return;
        }
        
        //reset elapsed time
        elapsedTime = 0;
    }
    public void DecrementGrowth() {
        _currentGrowthCycle--;

        if (_currentGrowthCycle <= 0)
        {
            // Game over you lost
            return;
        }
        //reset elapsed time
        elapsedTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //whenever the tree is triggered
        // check if the player has a heart
        // if so then increase the growth 
        // or else do nothing
        Player player = other.GetComponent<Player>();

        if (player)
        {
            if (player.HasHeart())
            {
                IncrementGrowth();
                player.RemoveHeart();
            }
        }
    }

    public bool IsDead()
    {
        if (_currentGrowthCycle <= 0)
        {
            return true;
        }
        return false;
    }

    public bool IsGrowthComplete()
    {
        if (_currentGrowthCycle >= _noOfGrowths)
        {
            return true;
        }
        return false;
    }
}
