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
    public GameObject[] Apagar;
    public Slider slider;
    public GameObject MenuFinal;


    public void Update()
    {
        if (slider.value == 100 && !Final.activeSelf)
        {
            light.SetActive(true);
            Final.SetActive(true);
            foreach(GameObject apa in Apagar)
            {
                apa.SetActive(false);
            }
            SonidoSnapZone.PlayOneShot(Sonidovictoria, 0.5f);
            Invoke("FinalCanvas", 3f);
        }
        if (slider.value < 100)
        {
            light.SetActive(false);
            Final.SetActive(false);
            foreach (GameObject apa in Apagar)
            {
                apa.SetActive(true);
            }
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

    public void FinalCanvas()
    {
        MenuFinal.SetActive(true);
    }
}
