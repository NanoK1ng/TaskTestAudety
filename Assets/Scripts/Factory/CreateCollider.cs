using System;
using UnityEngine;

namespace Assets.Scripts.Factory
{
    public class CreateCollider : MonoBehaviour
    {
        [SerializeField] private Transform _car;
        private readonly float _distanceX = 40;

        public event Action Collided;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Столкновение");
            Collided?.Invoke();
        }

        private void Awake() => DistanceToCar();

        private void FixedUpdate() => DistanceToCar();

        private void DistanceToCar() =>
            transform.position = _car.position - new Vector3(_distanceX, _car.position.y, _car.position.z);
    }
}