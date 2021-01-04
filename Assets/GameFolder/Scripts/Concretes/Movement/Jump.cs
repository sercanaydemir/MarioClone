using System;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.Movement
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 350f;
        public bool IsJump => _rb.velocity != Vector2.zero;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void JumpAction ()
        {
            _rb.AddForce(Vector2.up * jumpForce);
        }
    }
}