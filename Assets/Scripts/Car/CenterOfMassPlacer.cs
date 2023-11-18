using UnityEngine;

namespace Car
{
    public class CenterOfMassPlacer : MonoBehaviour
    {
        public float centerOfMassHeight = 0.5f;
    
        private void Start()
        {
            Rigidbody rigidboy = GetComponentInParent<Rigidbody>();
            rigidboy.centerOfMass = new Vector3(0, -centerOfMassHeight, 0);
        }
    }
}