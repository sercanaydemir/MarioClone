using UnityEngine;

namespace GameFolder.Scripts.Concretes.Movement
{
    public class FlipObj : MonoBehaviour
    {
        public bool FlipX { get; set; }

        public void Flip(SpriteRenderer spriteRenderer, float horizontal)
        {
            if (horizontal != 0)
            {
                spriteRenderer.flipX = (FlipX ? horizontal > 0 : horizontal < 0); //Ternary-If
            }
        }
    }
}