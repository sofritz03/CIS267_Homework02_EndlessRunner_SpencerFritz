//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject coin;
    public GameObject[] gems;
    public float spawnTime = 3f;
    public float coinChance = 0.5f;
    public float gemChance = 0.25f;

    private PlayerMovement player;

    void Start()
    {
        //find player
        player = FindAnyObjectByType<PlayerMovement>();

        //start spawning
        InvokeRepeating("SpawnObstacle", 2f, spawnTime);
    }

    void SpawnObstacle()
    {
        //pick random obstacle
        int randomObstacle = Random.Range(0, obstacles.Length);

        Vector3 obstaclePosition = transform.position;

        //crate
        if (randomObstacle == 0)
        {
            obstaclePosition.y = -2.5f;
        }

        //spear
        if (randomObstacle == 1)
        {
            obstaclePosition.y = 0.5f;
        }

        //arrow
        if (randomObstacle == 2)
        {
            obstaclePosition.y = -1.5f;
        }

        //spawn obstacle
        Instantiate(obstacles[randomObstacle], obstaclePosition, Quaternion.identity);

        //chance to spawn coin
        if (Random.value < coinChance)
        {
            Vector3 coinPosition = obstaclePosition;

            //put coin near obstacle
            coinPosition.x += 2f;
            coinPosition.y = -1f;

            Instantiate(coin, coinPosition, Quaternion.identity);
        }

        //spawn gem only if no gem is active
        if (!player.GemActive && Random.value < gemChance)
        {
            //pick random gem
            int randomGem = Random.Range(0, gems.Length);

            Vector3 gemPosition = obstaclePosition;

            //put gem near obstacle
            gemPosition.x += 3f;
            gemPosition.y = -1f;

            //spawn gem
            Instantiate(gems[randomGem], gemPosition, Quaternion.identity);
        }
    }
}