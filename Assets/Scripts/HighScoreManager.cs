//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static void SaveScore(int newScore)
    {
        //check top 5 scores
        for (int i = 0; i < 5; i++)
        {
            int savedScore = PlayerPrefs.GetInt("HighScore" + i, 0);

            //new score is higher
            if (newScore > savedScore)
            {
                //move lower scores down
                for (int j = 4; j > i; j--)
                {
                    int scoreAbove = PlayerPrefs.GetInt("HighScore" + (j - 1), 0);
                    PlayerPrefs.SetInt("HighScore" + j, scoreAbove);
                }

                //save new score
                PlayerPrefs.SetInt("HighScore" + i, newScore);
                PlayerPrefs.Save();

                break;
            }
        }
    }
}