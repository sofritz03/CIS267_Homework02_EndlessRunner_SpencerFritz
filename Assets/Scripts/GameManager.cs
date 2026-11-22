//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RestartGame()
    {
        //start game again
        Time.timeScale = 1f;

        //reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        //resume time
        Time.timeScale = 1f;

        //go to main menu
        SceneManager.LoadScene("MainMenu");
    }
}