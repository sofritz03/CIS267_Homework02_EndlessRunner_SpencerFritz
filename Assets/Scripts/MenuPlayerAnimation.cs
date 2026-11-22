//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;

public class MenuPlayerAnimation : MonoBehaviour
{
    public Sprite runSprite1;
    public Sprite runSprite2;
    public float animationSpeed = 0.15f;

    private SpriteRenderer spriteRenderer;
    private float timer;
    private bool firstSprite = true;

    void Start()
    {
        //get sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //run timer
        timer += Time.deltaTime;

        //switch sprite
        if (timer >= animationSpeed)
        {
            firstSprite = !firstSprite;

            if (firstSprite)
            {
                spriteRenderer.sprite = runSprite1;
            }
            else
            {
                spriteRenderer.sprite = runSprite2;
            }

            timer = 0f;
        }
    }
}