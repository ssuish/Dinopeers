using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceCropBehaviour : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    int RicemaxHP = 100;
    int RiceHP = 100;

    //Time used to determine plant growth stage
    float gameTimer = 1200f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (RiceHP <= 0)
        {
            Debug.Log("Crop Died");
            DestroyCrop();
        }
        riceGrowth();
     
    }

    void riceGrowth()
    {
        if (gameTimer <= 1200f && gameTimer > 820f && RiceHP > 0)
        {
            spriteRenderer.sprite = spriteArray[0];
        }
        else if (gameTimer <= 820f && gameTimer > 440f && RiceHP > 0)
        {
            spriteRenderer.sprite = spriteArray[1];
        }
        else if (gameTimer <= 440f && gameTimer > 60f && RiceHP > 0)
        {
            spriteRenderer.sprite = spriteArray[2];
        }
        else if (gameTimer <= 60f && RiceHP > 0)
        {
            spriteRenderer.sprite = spriteArray[3];
        }
    }

    void DestroyCrop()
    {
        Destroy(this.gameObject);
    }
}
