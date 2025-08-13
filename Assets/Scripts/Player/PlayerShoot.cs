using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Player.Inputs
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _player;
        [SerializeField] private float _speedBullet;
        [SerializeField] private Transform _spawnPointBullet;
        [SerializeField] private TMP_Text _numberOfBullets;
        [SerializeField] private int _currentNumberOfBullets;

        private PlayerAnimationController _playerAnimationController;
        private SoundController _soundController;

        private GameObject _currentBullet;
        private Rigidbody2D _currentBulletRigidbody;

        public int CurrentNumberOfBullet => _currentNumberOfBullets;

        public bool ICanShooting => _currentNumberOfBullets > 0;

        private void Start()
        {
            _playerAnimationController = GetComponent<PlayerAnimationController>();
            _soundController = GetComponentInChildren<SoundController>();
        }

        private void Update()
        {
            _numberOfBullets.text = _currentNumberOfBullets.ToString();
        }

        public void Shoot(bool _isShooting)
        {
            if (_isShooting == true)
            {
                Shooting();
                _isShooting = false;
            }
        }

        public void Shooting()
        {
            if (ICanShooting == true)
            {
                _playerAnimationController.Shoot();
                _soundController.AttackSound();
                _currentBullet = Instantiate(_bullet, _spawnPointBullet.position, Quaternion.identity);
                _currentBulletRigidbody = _currentBullet.GetComponent<Rigidbody2D>();
                _currentNumberOfBullets -= 1;

                if (_player.transform.localScale.x > 0)
                {
                    _currentBulletRigidbody.linearVelocity = new Vector2(_speedBullet * 1, _currentBulletRigidbody.linearVelocity.y);
                }

                else if (_player.transform.localScale.x < 0)
                {
                    _currentBulletRigidbody.linearVelocity = new Vector2(_speedBullet * -1, _currentBulletRigidbody.linearVelocity.y);
                }
            }
        }

        public void PickUpAmmo(int _ammoPoints)
        {
            _currentNumberOfBullets += _ammoPoints;
            _numberOfBullets.text = _currentNumberOfBullets.ToString();
        }
    }
}

