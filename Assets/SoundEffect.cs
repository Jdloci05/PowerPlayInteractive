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
    }

    private void PlayMalHechoSound()
    {
        SonidoSnapZone.PlayOneShot(SonidoMalo, VolumenSonidoMalo);
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
