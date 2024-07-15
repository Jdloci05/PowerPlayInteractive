using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource SonidoSnapZone;
    public AudioSource NPCAudioSource;

    public AudioClip SonidoBueno;
    public AudioClip SonidoMalo;
    public AudioClip Sonido3Malo;

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
        NPCAudioSource.clip = Sonido3Malo;
        NPCAudioSource.Play();
        yield return new WaitForSeconds(Sonido3Malo.length);
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
