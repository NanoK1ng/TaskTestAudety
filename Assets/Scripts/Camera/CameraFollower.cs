using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        private const float OffsetCameraZ = -10f;

        [SerializeField] private Transform _objectToFollow;
        [SerializeField] private Vector2 _offset = new(4f, 0f);

        private readonly float _smoothSpeed = 0.125f;

        private void LateUpdate()
        {
            if (_objectToFollow != null)
            {
                Vector2 desiredPosition = new Vector2(_objectToFollow.position.x, _objectToFollow.position.y) + _offset;
                Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, _smoothSpeed);
                transform.position = new(smoothedPosition.x, smoothedPosition.y, OffsetCameraZ);
            }
        }
    }
}