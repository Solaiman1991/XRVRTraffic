using System;
using UnityEngine;

namespace Navigation
{
    public class ArrowDirection : MonoBehaviour
    {
        [SerializeField] private Direction direction;

        public Direction GetDirection()
        {
            return direction;
        }
        public enum Direction {Left, Right, Stop};
    }
}
