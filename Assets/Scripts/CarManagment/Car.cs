using UnityEngine;

namespace Assets.Scripts.CarManagment
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Car : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
        }
    }
}