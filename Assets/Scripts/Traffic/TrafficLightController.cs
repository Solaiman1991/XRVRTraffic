using UnityEngine;

namespace Traffic
{
    public class TrafficLightController : MonoBehaviour
    {
        private CarBlocker _carBlocker;
    
        public GameObject upperGreenLightSphere;
        public GameObject upperYellowLightSphere;
        public GameObject upperRedLightSphere;

        public GameObject lowerGreenLightSphere;
        public GameObject lowerYellowLightSphere;
        public GameObject lowerRedLightSphere;

        public Light upperGreenLight;
        public Light upperYellowLight;
        public Light upperRedLight;

        public Light lowerGreenLight;
        public Light lowerYellowLight;
        public Light lowerRedLight;

        public Material greenOnMaterial, greenOffMaterial;
        public Material yellowOnMaterial, yellowOffMaterial;
        public Material redOnMaterial, redOffMaterial;

        public float greenTime = 5f;
        public float yellowTime = 2f;
        public float redTime = 5f;
        public float redYellowTime = 2f; 
    
        private float timer;
        public enum LightState { Green, Yellow, Red, RedAndYellow }
        public LightState currentState;

        public bool isManagedByIntersectionController = false;

        private void Awake()
        {
            _carBlocker = GetComponentInChildren<CarBlocker>();
        }

        void Start()
        {
            currentState = LightState.Red;
            timer = redTime;
            UpdateLights();
        }

        void Update()
        {
            if (!isManagedByIntersectionController)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    switch (currentState)
                    {
                        case LightState.Green:
                            currentState = LightState.Yellow;
                            timer = yellowTime;
                            break;
                        case LightState.Yellow:
                            currentState = LightState.Red;
                            timer = redTime;
                            break;
                        case LightState.Red:
                            currentState = LightState.RedAndYellow;
                            timer = redYellowTime;
                            break;
                        case LightState.RedAndYellow:
                            currentState = LightState.Green;
                            timer = greenTime;
                            break;
                    }
                    UpdateLights();
                }
            }
        }

        private void UpdateLights()
        {
            UpdateLightSet(upperGreenLightSphere, upperYellowLightSphere, upperRedLightSphere, upperGreenLight, upperYellowLight, upperRedLight);

            UpdateLightSet(lowerGreenLightSphere, lowerYellowLightSphere, lowerRedLightSphere, lowerGreenLight, lowerYellowLight, lowerRedLight);
        }

        private void UpdateLightSet(GameObject greenSphere, GameObject yellowSphere, GameObject redSphere, Light greenLight, Light yellowLight, Light redLight)
        {
            bool greenOn = currentState == LightState.Green;
            bool yellowOn = currentState == LightState.Yellow || currentState == LightState.RedAndYellow;
            bool redOn = currentState == LightState.Red || currentState == LightState.RedAndYellow;

            greenSphere.GetComponent<Renderer>().material = greenOn ? greenOnMaterial : greenOffMaterial;
            yellowSphere.GetComponent<Renderer>().material = yellowOn ? yellowOnMaterial : yellowOffMaterial;
            redSphere.GetComponent<Renderer>().material = redOn ? redOnMaterial : redOffMaterial;

            greenLight.enabled = greenOn;
            yellowLight.enabled = yellowOn;
            redLight.enabled = redOn;
        }

        public void SetGreenLight()
        {
            currentState = LightState.Green;
            timer = greenTime;
            UpdateLights();
            isManagedByIntersectionController = true;
        }

        public void SetYellowLight()
        {
            currentState = LightState.Yellow;
            timer = yellowTime;
            UpdateLights();
            isManagedByIntersectionController = true;
        
            _carBlocker.BlockCars();
        }

        public void SetRedLight()
        {
            currentState = LightState.Red;
            timer = redTime;
            UpdateLights();
            isManagedByIntersectionController = true;
        }
    
        public void SetRedAndYellowLight()
        {
            currentState = LightState.RedAndYellow;
            timer = redYellowTime;
            UpdateLights();
            isManagedByIntersectionController = true;
        
            _carBlocker.UnblockCars();
        }
    
        public LightState GetCurrentState()
        {
            return currentState;
        }
    
    }
}
