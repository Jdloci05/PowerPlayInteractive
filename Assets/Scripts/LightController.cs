using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public GameObject lightLED;

    public int puntos;
    public Slider slider;

    public GameObject mision;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Left Hand") || other.CompareTag("Right Hand"))
            lightLED.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Left Hand") || other.CompareTag("Right Hand"))
        {
            ProgressBar.RaiseSetProgressEvent((int)slider.value + puntos);
            mision.SetActive(true);
            lightLED.SetActive(false);
        }
            

    }
}
