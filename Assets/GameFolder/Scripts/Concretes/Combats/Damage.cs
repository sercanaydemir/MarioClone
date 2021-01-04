using UnityEngine;

namespace GameFolder.Scripts.Concretes.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private int damage;

        public int HitDamage => damage;

        public void HitTarget(Health health)
        {
            health.TakeHit(this);
        }
    }
}