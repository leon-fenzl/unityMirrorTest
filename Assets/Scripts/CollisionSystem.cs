using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    ArtemiasBehaviour shrimpCode;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("shrimp"))
        {
            shrimpCode = other.GetComponent<ArtemiasBehaviour>();
            shrimpCode.lightOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("shrimp"))
        {
            shrimpCode = other.GetComponent<ArtemiasBehaviour>();
            shrimpCode.lightOn = false;
        }
    }
}
