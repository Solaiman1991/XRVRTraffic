using UnityEngine;

namespace Car
{
    public class CenterOfMassPlacer : MonoBehaviour
    {
        public float centerOfMassHeight = 0.5f;

        private void Start()
        {
            var rigidboy = GetComponentInParent<Rigidbody>();
            rigidboy.centerOfMass = new Vector3(0, -centerOfMassHeight, 0);
        }
    }
}