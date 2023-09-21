using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedSoundPlayer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float timeInterval = 45f; // Tiempo en segundos entre cada reproducción.
    [SerializeField] private AudioClip soundToPlay;

    [Header("Events")]
    public UnityEvent OnSoundPlay;

    private AudioSource audioSource;
    private float timer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found!");
            return;
        }

        if (soundToPlay != null)
        {
            audioSource.clip = soundToPlay;
        }
        else
        {
            Debug.LogError("No audio clip assigned!");
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeInterval)
        {
            timer = 0f;
            PlaySound();
        }
    }

    private void PlaySound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            OnSoundPlay.Invoke();
        }
    }
}

