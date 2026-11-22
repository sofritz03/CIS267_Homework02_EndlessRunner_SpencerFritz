//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //start game
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void OpenHighScores()
    {
        //open high scores
        SceneManager.LoadScene("HighScores");
    }

    public void BackToMenu()
    {
        //back to main menu
        SceneManager.LoadScene("MainMenu");
    }
}