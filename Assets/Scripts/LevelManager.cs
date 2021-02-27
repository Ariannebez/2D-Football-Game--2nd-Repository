using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().resetgame();
    }

    public void LoadWinnerScene()
    {
        StartCoroutine(WaitAndLoadOver());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoadOver()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Win");
    }
}
