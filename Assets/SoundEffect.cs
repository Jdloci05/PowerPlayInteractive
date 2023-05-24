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


    public void BienHecho()
    {
        SonidoSnapZone.PlayOneShot(SonidoBueno, VolumenSonidoBueno);
    }

    public void MalHecho()
    {
        SonidoSnapZone.PlayOneShot(SonidoMalo, VolumenSonidoMalo);
    }
}
