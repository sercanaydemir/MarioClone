using System;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.Movement
{
    public class Climbing : MonoBehaviour
    {
        [SerializeField] private float climbSpeed = 5f;

        private Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rb => _rigidbody2D;
        public bool IsClimb { get; set; }
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Climb(float direction)
        {
            if (IsClimb)
            {
                transform.Translate(Vector3.up*direction*climbSpeed*Time.fixedDeltaTime);
            }            
        }
        
    }
}