//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        //follow player
        transform.position = new Vector3(player.position.x + 3f, transform.position.y, -10f);
    }
}