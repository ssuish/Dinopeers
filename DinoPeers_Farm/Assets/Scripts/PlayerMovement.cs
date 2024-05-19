using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool isMoving;
    public Vector2 input;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    public LayerMask boundaryLayer; 

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            if (input.x != 0)
            {
                _spriteRenderer.flipX = input.x > 0;
            }

            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (CanMoveTo(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
    }

    private bool CanMoveTo(Vector3 targetPos)
    {
        Bounds bounds = _boxCollider.bounds;
        bounds.center = targetPos;

        Collider2D boundaryCollider = Physics2D.OverlapBox(bounds.center, bounds.size, 0f, boundaryLayer);
        return boundaryCollider == null;
    }

    private IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        _animator.SetBool("IsMoving", true);
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        _animator.SetBool("IsMoving", false);
    }
}
