using UnityEngine;

namespace Navigation
{
    public class ArrowDirection : MonoBehaviour
    {
        public enum Direction
        {
            Left,
            Right,
            Stop
        }

        [SerializeField] private Direction direction;

        public Direction GetDirection()
        {
            return direction;
        }
    }
}