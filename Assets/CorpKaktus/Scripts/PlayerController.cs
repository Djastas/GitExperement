using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CorpKaktus.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float jumpStrength = 1f;
        [SerializeField] private float rotatePower = 1f;
        
        [Header("groundCheck")]
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float distance;
   
        [Header("Input")]
        [SerializeField] private InputAction moveAction;
        [SerializeField] private InputAction jumpAction;
    
        private Rigidbody2D _rb;
        
        private bool _canJump;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            moveAction.Enable();
            jumpAction.Enable();

            jumpAction.performed += _ => { Jump();};
        }

        private void Update()
        {
            if (!_canJump && IsGrounded()) { _canJump = true; }
            
            var moveValue =moveAction.ReadValue<float>();
            
            _rb.AddTorque(moveValue * rotatePower);
        }

        private bool IsGrounded() => Physics2D.Raycast(transform.position, Vector2.down,distance,groundLayer);

        private void OnDrawGizmos()
        {
            var direction = (Vector2.down * distance);
            Gizmos.DrawLine(transform.position,transform.position + new Vector3(direction.x,direction.y,0));
        }

        private void Jump()
        {
            if (!_canJump) return;
            _canJump = false;
            
            _rb.AddForce(Vector2.up * jumpStrength);
        }
    }
}
