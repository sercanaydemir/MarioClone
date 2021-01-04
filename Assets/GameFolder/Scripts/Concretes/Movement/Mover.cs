using UnityEngine;

namespace GameFolder.Scripts.Concretes.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        public void HorizontalMovement(float horizontal)
        {
            transform.Translate(Vector2.right * horizontal * speed * Time.fixedDeltaTime);
        }
    }
}