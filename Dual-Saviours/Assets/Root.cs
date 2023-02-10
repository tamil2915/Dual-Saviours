using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public int treeIndex;
    public int loverIndex;

    private const int _noOfGrowths = 4;

    public float cycleTime = 20f; // duration for each growth or death cycle

    int _currentGrowthCycle = 0;

    float elapsedTime = 0;

    public TreeManager treeManager;

    public GameObject[] treeModels;
    public Transform treePosition;

    bool isGameOver = false;

    public UIManager uiManager;
    public AudioManager audioManager;

    private void Start()
    {
        UpdateTree();
    }

    private void Update()
    {
        if (isGameOver)
            return;

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= cycleTime)
        {
            if (GetCurrentGrowthCycle() >= 0)
            //check for the currentStatus
                DecrementGrowth();
        }
    }

    public int GetCurrentGrowthCycle()
    {
        return _currentGrowthCycle;
    }

    void UpdateTree()
    {
        for (int i= 0; i < _noOfGrowths; i++)
        {
            if (i == _currentGrowthCycle)
            {
                treeModels[i].SetActive(true) ;
            }
            else
            {
                treeModels[i].SetActive(false);
            }
        }
    }

    public void IncrementGrowth() 
    {    
        _currentGrowthCycle++;


        if (_currentGrowthCycle >= _noOfGrowths-1)
        {
            UpdateTree();
            audioManager.PlayTreeGrowSound();
            //Game over game complete
            isGameOver = true;
            return;
        }
        else
        {
            //put the appropriate tree model
            UpdateTree();
        }
        audioManager.PlayTreeGrowSound();
        
        //reset elapsed time
        elapsedTime = 0;
    }

    


    public void DecrementGrowth() {
        _currentGrowthCycle--;

        if (_currentGrowthCycle < 0)
        {
            // Game over you lost
           // UpdateTree();
            isGameOver = true;
            return;
        }
        else
        {
            //put the appropriate tree model
            UpdateTree();
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

        if (isGameOver)
            return;

        if (!treeManager.CheckIfValidMove(treeIndex, loverIndex))
            return;
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
        if (_currentGrowthCycle < 0)
        {
            return true;
        }
        return false;
    }

    public bool IsGrowthComplete()
    {
        if (_currentGrowthCycle >= _noOfGrowths-1)
        {
            return true;
        }
        return false;
    }

    public float GetRemainingTimeForTree()
    {
        return Mathf.Round(cycleTime - elapsedTime);
    }
}
