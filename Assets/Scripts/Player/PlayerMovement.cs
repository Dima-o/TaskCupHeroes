using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;

    private Rigidbody2D _rb;

    private bool _activeMove;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _activeMove = true;
    }

    private void FixedUpdate()
    {
        if (_activeMove)
        {
            Move();
        }
        else
        {
            FreezePlayer();
        }
    }

    private void Move()
    {
        UnfreezePlayer();
        _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);
    }

    private void FreezePlayer()
    {
        _rb.velocity = Vector2.zero;
        _rb.isKinematic = true;
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void UnfreezePlayer()
    {
        _rb.isKinematic = false;
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void IsActiveMovement(bool active)
    {
        _activeMove = active;
    }
}
