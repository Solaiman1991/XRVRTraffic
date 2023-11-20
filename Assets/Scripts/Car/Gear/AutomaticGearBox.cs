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

        public void ShiftToPark()
        {
            _currentGearIndex = (int)Gear.Park;
        }
        
        public void ShiftToDrive()
        {
            _currentGearIndex = (int)Gear.Drive;
        }
        
        public void ShiftToReverse()
        {
            _currentGearIndex = (int)Gear.Reverse;
        }
        
        public void ShiftToNeutral()
        {
            _currentGearIndex = (int)Gear.Neutral;
        }
    }
    
    public enum Gear
    {
        Park,
        Reverse,
        Neutral,
        Drive
    }
}