using UnityEngine;

namespace Camera
{
    public class FollowObject : MonoBehaviour
    {
        public Transform objectToFollow;

        private Vector3 _offset;
        private float _originalY;
    
        private void Awake()
        {
            var position = transform.position;
            _offset = position - objectToFollow.position;
            _originalY = position.y;
        }

        private void LateUpdate()
        {
            var newPosition = objectToFollow.position + _offset;
            newPosition.y = _originalY;
            transform.position = newPosition;
        }
    }
}
