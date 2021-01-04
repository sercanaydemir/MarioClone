using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project2.Controller
{
    public class GroundController : MonoBehaviour
    {
        [SerializeField] private Transform[] translate;
        [SerializeField] private bool isGround = false;
        [FormerlySerializedAs("layerMask")] [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float maxDistance = 0.1f;

        public bool IsGround => isGround;
        private void Update()
        {
            foreach (var foot in translate)
            {
                GroundCheck(foot);
                
                if(isGround) break;
            }
        }

        private void GroundCheck(Transform foot)
        {
            RaycastHit2D hit = Physics2D.Raycast(foot.position, foot.forward, maxDistance, groundLayer);

            if (hit.collider != null)
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
        }
    }
}