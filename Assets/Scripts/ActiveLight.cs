using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveLight : MonoBehaviour
{
    public AudioSource SonidoSnapZone;
    public AudioClip Sonidovictoria;

    public GameObject light;
    public GameObject progress;
    public GameObject Final;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public Slider slider;


    public void Update()
    {
        if (slider.value == 100 && !Final.activeSelf)
        {
            light.SetActive(true);
            Final.SetActive(true);
            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
            SonidoSnapZone.PlayOneShot(Sonidovictoria, 0.5f);
        }
        if (slider.value < 100)
        {
            light.SetActive(false);
            Final.SetActive(false);
            Text1.SetActive(true);
            Text2.SetActive(true);
            Text3.SetActive(true);
            progress.SetActive(true);
        }
    }

    public void completo()
    {
        if (slider.value == 100)
        {
            
        }
        if (slider.value < 100)
        {
            light.SetActive(false);
            Final.SetActive(false);
            progress.SetActive(true);
        }
    }
}
