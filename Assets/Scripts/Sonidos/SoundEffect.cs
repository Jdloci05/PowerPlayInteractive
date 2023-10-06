using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource SonidoSnapZone;

    public AudioClip SonidoBueno;
    public AudioClip SonidoMalo;

    public float VolumenSonidoBueno;
    public float VolumenSonidoMalo;

    public static event Action OnBienHecho;
    public static event Action OnMalHecho;

    public GameObject AdviceCanvas;
    private int wrongCount = 0;

    private void OnEnable()
    {
        OnBienHecho += PlayBienHechoSound;
        OnMalHecho += PlayMalHechoSound;
    }

    private void OnDisable()
    {
        OnBienHecho -= PlayBienHechoSound;
        OnMalHecho -= PlayMalHechoSound;
    }

    private void PlayBienHechoSound()
    {
        SonidoSnapZone.PlayOneShot(SonidoBueno, VolumenSonidoBueno);
        wrongCount = 0;
    }

    private void PlayMalHechoSound()
    {
        SonidoSnapZone.PlayOneShot(SonidoMalo, VolumenSonidoMalo);
        wrongCount++; 

        if (wrongCount == 3)
        {
            DisplayAdvice();
            wrongCount = 0; 
        }
    }

    private void DisplayAdvice()
    {
        AdviceCanvas.SetActive(true);
        StartCoroutine(DeactivateAdvice());
    }

    private IEnumerator DeactivateAdvice()
    {
        yield return new WaitForSeconds(10);
        AdviceCanvas.SetActive(false); 
    }

    public void RaiseBienHechoEvent()
    {
        OnBienHecho?.Invoke();
    }

    public void RaiseMalHechoEvent()
    {
        OnMalHecho?.Invoke();
    }
}
