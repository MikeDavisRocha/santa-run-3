using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerInput : MonoBehaviour
{
    [Header("New Jump Values")]
    private float _jumpGravity;
    [SerializeField] private float JumpHeight;
    [SerializeField] private float TimeToJumpHeight;
    private float _jumpVelocity;
    private Vector3 stepMovement;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _gravity;

    public LayerMask _floorLayerMask;
    BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }


    private void Start()
    {
        // Calculate the gravity and initial jump velocity values 
        _jumpGravity = -(2 * JumpHeight) / Mathf.Pow(TimeToJumpHeight, 2);
        _jumpVelocity = Mathf.Abs(_jumpGravity) * TimeToJumpHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            _velocity.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _velocity.y = _jumpVelocity;
        }

        // Step update
        stepMovement = (_velocity + Vector3.up * _gravity * Time.deltaTime * 0.5f) * Time.deltaTime;
        transform.Translate(stepMovement);
        _velocity.y += _gravity * Time.deltaTime;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, 1f, _floorLayerMask);
        return raycastHit2D.collider != null;
    }
}
