using System;
using GameFolder.Scripts.Concretes.Managers;
using UnityEngine;

namespace Project2.Controller
{
    public class HouseController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                GameManager.Instance.LoadScene();
            }
        }
    }
}