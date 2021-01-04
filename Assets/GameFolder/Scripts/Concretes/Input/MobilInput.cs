using System.Collections;
using System.Collections.Generic;
using Project2.Abstract.Inputs;
using UnityEngine;

namespace Project2.Inputs
{
    public class MobilInput : IPlayerInput
    {
        public float Horizontal { get; }
        public float Vertical { get; }
        public bool IsJumpButtonDown { get; }
    }   
}
