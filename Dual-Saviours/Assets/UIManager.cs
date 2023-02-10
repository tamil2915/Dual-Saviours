using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Player prince;
    public Player princess;

    public Root topTree;
    public Root bottomTree;

    public TextMeshProUGUI topTreeText;
    public TextMeshProUGUI bottomTreeText;

    public GameObject gameOverPositive;
    public GameObject gameOverNegative;

    public bool IsGameOver = false;
    public CameraManager cameraManager;

    public AudioManager audioManager;

    public void UpdateTopTreeHearts()
    {
        topTreeText.SetText(topTree.GetRemainingTimeForTree().ToString());
    }

    public void UpdateBottomTreeHearts()
    {
        bottomTreeText.SetText(bottomTree.GetRemainingTimeForTree().ToString());
    }

    private void Update()
    {
        UpdateTopTreeHearts();
        UpdateBottomTreeHearts();
    }

    public void GameOverPositive()
    {
        IsGameOver = true;
        StartCoroutine(SetGamePositiveScreen());
        cameraManager.GameOver();
        audioManager.PlayGameOverPositiveSound();

    }

    public void GameOverNegative() {
        IsGameOver = true;
        StartCoroutine(SetGameNegativeScreen());
        cameraManager.GameOver();
    }

    IEnumerator SetGameNegativeScreen()
    {
        yield return new WaitForSeconds(1);
        gameOverNegative.SetActive(true);
    }

    IEnumerator SetGamePositiveScreen()
    {
        yield return new WaitForSeconds(1);
        gameOverPositive.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
