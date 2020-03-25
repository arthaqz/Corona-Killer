using UnityEngine;

namespace UI.Game
{
    public class PlayerLightFollow : MonoBehaviour
    {
        public Transform target;

        public float smoothSpeed;
        public Vector3 offset;

        private Vector3 desiredPosition;
        private Vector3 smoothedPosition;

        private void FixedUpdate()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            desiredPosition = target.position + offset;
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);

            transform.position = smoothedPosition;

        }
    }
}