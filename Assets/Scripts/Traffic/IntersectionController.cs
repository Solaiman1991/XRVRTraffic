using UnityEngine;
using System.Collections;

public class IntersectionController : MonoBehaviour
{
    public TrafficLightController northTrafficLight;
    public TrafficLightController southTrafficLight;
    public TrafficLightController eastTrafficLight;
    public TrafficLightController westTrafficLight;

    public float greenLightDuration = 10f;
    public float allRedDuration = 2f; 
    public float redYellowTransitionDuration = 2f;

    void Start()
    {
        StartCoroutine(ControlIntersection());
    }

    IEnumerator ControlIntersection()
    {
        while (true)
        {
            // North-South 
            yield return StartCoroutine(ManageTrafficLightSequence(northTrafficLight, southTrafficLight));

            // All red 
            yield return new WaitForSeconds(allRedDuration);

            // East-West 
            yield return StartCoroutine(ManageTrafficLightSequence(eastTrafficLight, westTrafficLight));

            // All red 
            yield return new WaitForSeconds(allRedDuration);
        }
    }

    IEnumerator ManageTrafficLightSequence(TrafficLightController light1, TrafficLightController light2)
    {
        // Red to Red + Yellow 
        light1.SetRedAndYellowLight();
        light2.SetRedAndYellowLight();
        yield return new WaitForSeconds(redYellowTransitionDuration);

        // Green 
        light1.SetGreenLight();
        light2.SetGreenLight();
        yield return new WaitForSeconds(greenLightDuration);

        // Yellow 
        light1.SetYellowLight();
        light2.SetYellowLight();
        yield return new WaitForSeconds(light1.yellowTime);

        // Red 
        light1.SetRedLight();
        light2.SetRedLight();
    }
}
