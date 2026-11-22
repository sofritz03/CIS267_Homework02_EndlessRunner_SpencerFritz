//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        //move obstacle left
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}