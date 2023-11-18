using Input;
using UnityEngine;

namespace Car.ArrowBlinker
{
    public class ArrowBlinkerManager : MonoBehaviour
    {
        private IInputManager _inputManager;
        private global::ArrowBlinker _arrowBlinker;

        private void Start()
        {
            _inputManager = GetComponent<IInputManager>();
            _arrowBlinker = GetComponent<global::ArrowBlinker>();

            if (_inputManager == null || _arrowBlinker == null)
            {
                Debug.LogWarning("ArrowBlinkerManager requires IInputManager and ArrowBlinker components");
            }
        }

        private void Update()
        {
            if (_inputManager == null ) return;

            if (_inputManager.GetLeftSignInput())
            {
                _arrowBlinker.ToggleLeftBlinking();
            }
            
            if (_inputManager.GetRightSignInput())
            {
                _arrowBlinker.ToggleRightBlinking();
            }

            if (_inputManager.GetHavariSignInput())
            {
                _arrowBlinker.ToggleHavariBlinking();
            }
        }
    }
}
