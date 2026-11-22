//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed = 5f;
    public float resetPosition = -20f;
    public float moveForward = 60f;

    void Update()
    {
        //move ground left
        transform.position += Vector3.left * speed * Time.deltaTime;

        //move ground back to the right
        if (transform.position.x <= resetPosition)
        {
            transform.position += Vector3.right * moveForward;
        }
    }
}