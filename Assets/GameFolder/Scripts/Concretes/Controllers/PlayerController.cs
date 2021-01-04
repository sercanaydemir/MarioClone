using System;
using System.Collections;
using System.Collections.Generic;
using GameFolder.Scripts.Concretes.Animation;
using GameFolder.Scripts.Concretes.Combats;
using GameFolder.Scripts.Concretes.ExtensionMethods;
using GameFolder.Scripts.Concretes.Movement;
using GameFolder.Scripts.Concretes.UIScripts;
using MyNamespace;
using Project2.Abstract.Inputs;
using TMPro;
using UnityEngine;

namespace Project2.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private AudioClip deadClip;

        [Header("Components")]
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rb;
        private Mover _mover;
        private Jump _jump;
        private CharacterAnimation _characterAnimation;
        private FlipObj _flipPlayer;
        private GroundController _groundController;
        private Climbing _climbing;
        private Health _health;
        private Damage _damage;
        private AudioSource _audioSource;
        
        [Header("Variables")]
        private bool _flipX;
        private float _horizontal;
        private bool _isJump;
        private float _vertical;
        
        [Header("Class")]
        private IPlayerInput _input;

        public static event Action<AudioClip> OnPlayDeadSound;
        
        void Awake()
        {
            CacheProgress();
        }

        private void Start()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if (gameCanvas != null)
            {
                DisplayHealth displayHealth = FindObjectOfType<DisplayHealth>();
                _health.OnHealthChanged += displayHealth.WriteHealth;
                _health.OnDead += gameCanvas.ShowGameOverPanel;
                displayHealth.WriteHealth(_health.MaxHealth,0);
            }

            _health.OnDead += () => OnPlayDeadSound?.Invoke(deadClip);
            _health.OnHealthChanged += PlayDamageSound;
        }

        #region CacheProgress

        private void CacheProgress()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _jump = GetComponent<Jump>();
            _input = new PcInput();
            _mover = GetComponent<Mover>();
            _characterAnimation = GetComponent<CharacterAnimation>();
            _flipPlayer = GetComponent<FlipObj>();
            _groundController = GetComponent<GroundController>();
            _climbing = GetComponent<Climbing>();
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();
            _audioSource = GetComponent<AudioSource>();
        }

        #endregion

        void Update()
        {
            if (_health.IsDead) return;
            
            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;
            
            if (_input.IsJumpButtonDown && _groundController.IsGround)
            {
                _isJump = true;
            }
        }

        private void FixedUpdate()
        {
            _mover.HorizontalMovement(_horizontal);
            _climbing.Climb(_vertical);
            
            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }
        }

        private void LateUpdate()
        {
            _characterAnimation.JumpAnimation(_jump.IsJump && !_groundController.IsGround);
            _characterAnimation.MoveAnimation(_horizontal);
            _characterAnimation.ClimbAnimation(_climbing.IsClimb,_vertical);
            _flipPlayer.Flip(_spriteRenderer,_horizontal);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Health health = other.ObjectHasHealth();
            
            if (health !=null &&
                other.WasHitTopSide(0.75f))
            {
                _jump.JumpAction();
                _damage.HitTarget(health);
            }
        }

        void PlayDamageSound(int currentHealth, int maxHealth)
        {
            _audioSource.Play();
        }
    }
    
    
    
}
