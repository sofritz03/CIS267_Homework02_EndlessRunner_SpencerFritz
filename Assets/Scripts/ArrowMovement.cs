//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================

using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float arrowSpeed = 10f;

    void Update()
    {
        //shoot arrow left
        transform.position += Vector3.left * arrowSpeed * Time.deltaTime;
    }
}