using Assets.Scripts.CarManagment;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class ButtonRotation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private CarRotation _carRotation;
        [SerializeField] private bool _positiveValue;

        private bool _isPressed = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }

        private void Update()
        {
            if (_isPressed)
            {
                _carRotation.Rotation(_positiveValue);
            }
        }
    }
}