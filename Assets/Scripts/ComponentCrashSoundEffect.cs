using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class ComponentCrashSoundEffect : MonoBehaviour
{
    public AudioClip collisionClip; // Asigna este clip desde el Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Obt�n el componente AudioSource del objeto y config�ralo
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collisionClip;
        // Configura el AudioSource para que no se reproduzca autom�ticamente al iniciar
        audioSource.playOnAwake = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Calcula la velocidad relativa del impacto
        float impactVelocity = collision.relativeVelocity.magnitude;

        // Calcula el volumen basado en la velocidad del impacto
        // Aqu� puedes ajustar la f�rmula seg�n lo que consideres adecuado para tu juego
        float volume = Mathf.Clamp(impactVelocity / 10f, 0f, 1f);

        volume -= 0.05f;

        // Reproduce el sonido con el volumen calculado
        audioSource.volume = volume;
        audioSource.Play();
    }
}