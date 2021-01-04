using System;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.Animation
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        private Animator _anim;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        public void MoveAnimation(float horizontal)
        {
            float mathfValue = Mathf.Abs(horizontal);
            
            if (_anim.GetFloat("moveSpeed") == mathfValue) return;
            
            _anim.SetFloat("moveSpeed", mathfValue);
        }

        public void DyingAnimation()
        {
            _anim.SetTrigger("Dying");
        }

        public void JumpAnimation( bool isJump)
        {
            if (_anim.GetBool("isJump") == isJump) return;
            
            _anim.SetBool("isJump", isJump);
        }

        public void ClimbAnimation(bool isClimb, float horizontal)
        {

            if (_anim.GetBool("isClimb") != isClimb && horizontal != 0)
            {
                Debug.Log(horizontal);
                _anim.SetBool("isClimb", isClimb);
            }
            else
            {
                _anim.SetBool("isClimb", false);
            }
            


        }
    }
}