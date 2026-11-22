//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TMP_Text highScoresText;

    void Start()
    {
        //get saved scores
        int score1 = PlayerPrefs.GetInt("HighScore0", 0);
        int score2 = PlayerPrefs.GetInt("HighScore1", 0);
        int score3 = PlayerPrefs.GetInt("HighScore2", 0);
        int score4 = PlayerPrefs.GetInt("HighScore3", 0);
        int score5 = PlayerPrefs.GetInt("HighScore4", 0);

        //show top 5
        highScoresText.text = "1. " + score1 + "\n" + "2. " + score2 + "\n" + "3. " + score3 + "\n" + "4. " + score4 + "\n" + "5. " + score5;
    }
}