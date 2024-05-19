using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAC : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipTowardsPlayer();
    }
    
    void FlipTowardsPlayer()
    {
        if (player.position.x < transform.position.x)
        {
            _spriteRenderer.flipX = false;
        }
        else 
        {
            _spriteRenderer.flipX = true;
        }
    }
}
