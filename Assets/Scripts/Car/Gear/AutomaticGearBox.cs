using UnityEngine;

namespace Car.Gear
{
    public class AutomaticGearBox : MonoBehaviour
    {
        private int _currentGearIndex;
        private readonly Gear[] _gears = new[] { Gear.Park, Gear.Reverse, Gear.Neutral, Gear.Drive };

        public Gear GetCurrentGear()
        {
            return _gears[_currentGearIndex];
        }
        
        public void UpShift()
        {
            _currentGearIndex++;
            if (_currentGearIndex > _gears.Length - 1)
            {
                _currentGearIndex--;
            }
        }

        public void DownShift()
        {
            _currentGearIndex--;
            if (_currentGearIndex < 0)
            {
                _currentGearIndex++;
            }
        }
    }
    
    public enum Gear
    {
        Park,
        Neutral,
        Drive,
        Reverse
    }
}