using System;
using UnityEngine;

namespace Assets.Scripts.CarManagment
{
    public class DeathCollider : MonoBehaviour
    {
        public event Action OnDeath;

        private void OnTriggerEnter2D(Collider2D collision) => OnDeath?.Invoke();
    }
}