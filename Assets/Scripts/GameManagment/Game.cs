using Assets.Scripts.CarManagment;
using System;
using UnityEngine;

namespace Assets.Scripts.GameManagment
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private DeathCollider _deathCollider;
        [SerializeField] private Car _car;

        private Rigidbody2D _rigidbody2DCar;

        public event Action OnGameOver;
        public event Action GameStarted;

        public void StartGame()
        {
            GameStarted?.Invoke();
            SetValueCarZero();

            Time.timeScale = 1;
        }

        private void OnEnable()
        {
            _deathCollider.OnDeath += GameOver;
        }

        private void OnDisable()
        {
            _deathCollider.OnDeath -= GameOver;
        }

        private void Awake()
        {
            Time.timeScale = 0;

            _rigidbody2DCar = _car.GetComponent<Rigidbody2D>();

            DontDestroyOnLoad(this);
        }

        private void GameOver()
        {
            OnGameOver?.Invoke();
            Time.timeScale = 0;
            Debug.Log("Game Over!");
        }

        private void SetValueCarZero()
        {
            _rigidbody2DCar.angularVelocity = 0f;
            _rigidbody2DCar.velocity = Vector3.zero;
            _car.transform.rotation = Quaternion.Euler(Vector3.zero);
            _car.transform.position = Vector3.zero;
        }
    }
}