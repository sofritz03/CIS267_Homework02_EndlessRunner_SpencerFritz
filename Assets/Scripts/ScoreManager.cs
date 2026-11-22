//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text distanceText;

    private int coinPoints = 0;
    private float distance = 0f;

    void Start()
    {
        //show starting score
        scoreText.text = "Score: 0";
        distanceText.text = "Distance: 0";
    }

    void Update()
    {
        //add distance
        distance += Time.deltaTime * 5f;

        //get total score
        int totalScore = coinPoints + Mathf.FloorToInt(distance);

        //update text
        scoreText.text = "Score: " + totalScore;
        distanceText.text = "Distance: " + Mathf.FloorToInt(distance);
    }

    public void AddScore(int amount)
    {
        //add coin points
        coinPoints += amount;
    }

    public int GetScore()
    {
        //get final score
        return coinPoints + Mathf.FloorToInt(distance);
    }
}