using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(0, 1)]
        public float motionSmoothTime;
        
        private Animator _animator;
        private static readonly int XMotionHash = Animator.StringToHash("X Motion");
        private static readonly int ZMotionHash = Animator.StringToHash("Z Motion");

        private Vector2 _motion, _currentMotion;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            // Read the inputs
            var direction = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );
            
            // Smooth the motion vector
            _motion = Vector2.SmoothDamp(_motion, direction, ref _currentMotion, motionSmoothTime);
            
            // Write the smoothed values
            _animator.SetFloat(XMotionHash, _motion.x);
            _animator.SetFloat(ZMotionHash, _motion.y);
        }
    }
}
