using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Abstract.Inputs
{
 
    public interface IPlayerInput 
    {
        float Horizontal { get; } 
        float Vertical { get; }
        bool IsJumpButtonDown { get; }
    }   
}
