using UnityEngine;

namespace Assets.Scripts.CarManagment
{
    public class CarRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 30f;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Rotation(bool positiveValue)
        {
            _rigidbody2D.AddTorque(positiveValue ? (_rotationSpeed * -1) : _rotationSpeed);
        }
    }
}