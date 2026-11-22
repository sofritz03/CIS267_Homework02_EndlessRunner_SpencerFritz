//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;

public class SwingMovement : MonoBehaviour
{
    public float swingSpeed = 2f;
    public float swingAngle = 45f;

    void Update()
    {
        //swing back and forth
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;

        //rotate obstacle
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}