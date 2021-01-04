using System;
using GameFolder.Scripts.Concretes.Movement;
using UnityEngine;

namespace Project2.Controller
{
    public class LadderController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterExit(other,0f,true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerEnterExit(other,2f,false);
        }

        void OnTriggerEnterExit(Collider2D collision,float gravityForce,bool isClimbing)
        {
            Climbing player = collision.GetComponent<Climbing>();

            if (player != null)
            {
                player.IsClimb = isClimbing;
                player.Rb.gravityScale = gravityForce;
            }
        }
    }
}