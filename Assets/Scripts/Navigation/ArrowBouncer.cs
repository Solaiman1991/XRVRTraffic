using UnityEngine;

namespace Navigation
{
    public class ArrowBouncer : MonoBehaviour
    {
        [SerializeField] private float floatSpan = 2.0f;
        [SerializeField] private float speed  = 1.0f;

        private float startY;

        void Start() {
            startY = transform.position.y;
        }

        void Update()
        {
            var transformPosition = transform.position;
            transformPosition.y = startY + Mathf.Sin(Time.time * speed) * floatSpan / 2.0f;
            transform.position = transformPosition;
        }
    }
}
