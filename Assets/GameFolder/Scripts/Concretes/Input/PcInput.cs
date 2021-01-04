using System.Collections;
using System.Collections.Generic;
using Project2.Abstract.Inputs;
using UnityEngine;

namespace MyNamespace
{
    public class PcInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    
    }   
}
