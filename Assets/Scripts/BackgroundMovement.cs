//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float speed = 2f;
    public float resetPosition = -20f;
    public float moveForward = 60f;

    void Update()
    {
        //move background left
        transform.position += Vector3.left * speed * Time.deltaTime;

        //move background back
        if (transform.position.x <= resetPosition)
        {
            transform.position += Vector3.right * moveForward;
        }
    }
}
