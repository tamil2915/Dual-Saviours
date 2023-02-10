using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{
    public GameObject instructions;
    public GameObject story;


    public void OpenStory()
    {
        story.gameObject.SetActive(true);
    }

    public void CloseStory()
    {
        story.gameObject.SetActive(false);
    }

    public void OpenInstructions() {
        instructions.gameObject.SetActive(true);
    }

    public void CloseInstructions() {
        instructions.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
