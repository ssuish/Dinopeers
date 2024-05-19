using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public bool isMoving;
    private Vector2 input;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementContactFilter;
    private Rigidbody2D _rigidbody2D;
    List<RaycastHit2D> _hitBuffer = new List<RaycastHit2D>(16);
    private bool _canMove = true;
    private PlayerInput _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_canMove)
        {
            input = _playerInput.actions["Move"].ReadValue<Vector2>();
            
            if (input.x != 0)
            {
                _spriteRenderer.flipX = input.x > 0;
            }

            if (input != Vector2.zero)  
            {
                bool success = TryMove(input);

                

                _animator.SetBool("IsMoving", success);
            }
            else
            {
                _animator.SetBool("IsMoving", false);
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = _rigidbody2D.Cast(
                Vector2.zero, 
                movementContactFilter, 
                _hitBuffer,
                moveSpeed * Time.deltaTime + collisionOffset);

            if (count == 0)
            {
                _rigidbody2D.MovePosition(_rigidbody2D.position + direction * moveSpeed * Time.deltaTime);
                return true;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Vector2 currentNormal = _hitBuffer[i].normal;
                    Vector2 alongNormal = Vector2.Dot(direction, currentNormal) * currentNormal;
                    Vector2 tangentMovement = direction - alongNormal;
                    if (_rigidbody2D.Cast(tangentMovement, movementContactFilter, _hitBuffer, moveSpeed * Time.fixedDeltaTime + collisionOffset) == 0)
                    {
                        _rigidbody2D.MovePosition(_rigidbody2D.position + tangentMovement * moveSpeed * Time.deltaTime);
                        return true;
                    }
                }
                return false;
            }
               
        }
        else
            return false;
    }

    /*private bool CanMoveTo(Vector3 targetPos)
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
    */
}
