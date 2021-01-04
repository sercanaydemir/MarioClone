using System;
using GameFolder.Scripts.Concretes.Animation;
using GameFolder.Scripts.Concretes.Combats;
using GameFolder.Scripts.Concretes.ExtensionMethods;
using GameFolder.Scripts.Concretes.Managers;
using GameFolder.Scripts.Concretes.Movement;
using UnityEngine;

namespace Project2.Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private AudioClip deadClip;
        private Mover _mover;
        private Health _health;
        private Damage _damage;
        private FlipObj _flipPlayer;
        private OnReachedEdge _onReachedEdge;
        private SpriteRenderer _spriteRenderer;
        private CharacterAnimation _characterAnimation;

        private float _horizontal;

        public static event System.Action<AudioClip> OnEnemyDead;
        private void Awake()
        {
            CacheComponents();
            _horizontal = 1;
        }

        #region CacheComponents

        private void CacheComponents()
        {
            _mover = GetComponent<Mover>();
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();
            _flipPlayer = GetComponent<FlipObj>();
            _onReachedEdge = GetComponent<OnReachedEdge>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _characterAnimation = GetComponent<CharacterAnimation>();
        }

        #endregion

        private void OnEnable()
        {
            _health.OnDead += DeadAction;
            _health.OnDead += () => OnEnemyDead?.Invoke(deadClip);
        }

        private void FixedUpdate()
        {
            if (_health.IsDead) return;
            
            _mover.HorizontalMovement(_horizontal);
        }

        private void LateUpdate()
        {
            if (_onReachedEdge.ReachedEdge())
            {
                _horizontal *= -1;
                _flipPlayer.Flip(_spriteRenderer,_horizontal);
            }
            
            _characterAnimation.MoveAnimation(_horizontal);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Health health = other.ObjectHasHealth();
            
            if ( health !=null && other.WasHitLeftOrRightSide(0.75f))
            {
                
                _damage.HitTarget(health);
            }
        }

        void DeadAction()
        {
            _characterAnimation.DyingAnimation();
            Destroy(this.gameObject,0.4f);
        }
    }
}