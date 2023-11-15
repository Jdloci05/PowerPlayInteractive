using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGBController : MonoBehaviour
{
    public Light lightRGB;

    public int puntos;
    public Slider slider;

    public GameObject mision;

    public Color newColor;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left Hand") || other.CompareTag("Right Hand")) 
        {
            CambiarColor();
            mision.SetActive(true);
            ProgressBar.RaiseSetProgressEvent((int)slider.value + puntos);
        }
    }

    public void CambiarColor()
    {
        newColor.r = Random.Range(0.0f, 1.0f);
        newColor.g = Random.Range(0.0f, 1.0f);
        newColor.b = Random.Range(0.0f, 1.0f);

        lightRGB.color = newColor;
    }
}
