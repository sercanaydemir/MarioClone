using GameFolder.Scripts.Concretes.Combats;
using Project2.Controller;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.ExtensionMethods
{
    public static class CollisionExtensionMethods 
    {
        public static bool WasHitLeftOrRightSide(this Collision2D collision2D,float x)
        {
            return collision2D.contacts[0].normal.x > x || collision2D.contacts[0].normal.x < -x;
        }

        public static bool WasHitBottomSide(this Collision2D collision2D, float y)
        {
            return collision2D.contacts[0].normal.y < -y;
        }

        public static bool WasHitTopSide(this Collision2D collision2D, float y)
        {
            return collision2D.contacts[0].normal.y > y;
        }

        public static bool HasHitPlayer(this Collision2D collision2D)
        {
            return collision2D.collider.transform.GetComponent<PlayerController>() != null;
        }

        public static bool HasHitEnemy(this Collision2D collision2D)
        {
            return collision2D.collider.transform.GetComponent<EnemyController>() != null;
        }

        public static Health ObjectHasHealth(this Collision2D collision2D)
        {
            Health health = collision2D.collider.GetComponent<Health>();

            if (health != null)
            {
                return health;
            }

            return null;
        }
    }
}