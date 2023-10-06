using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    // Keep the events private
    private static event Action<int> OnSetMaxProgress;
    private static event Action<int> OnSetProgress;

    private void OnEnable()
    {
        // Subscribe to events
        OnSetMaxProgress += SetMaxProgress;
        OnSetProgress += SetProgress;
    }

    private void OnDisable()
    {
        // Unsubscribe from events
        OnSetMaxProgress -= SetMaxProgress;
        OnSetProgress -= SetProgress;
    }

    private void SetMaxProgress(int progress)
    {
        slider.maxValue = progress;
        slider.value = progress;
    }

    private void SetProgress(int progress)
    {
        slider.value = progress;
    }

    // Public methods to raise the events
    public static void RaiseSetMaxProgressEvent(int progress)
    {
        OnSetMaxProgress?.Invoke(progress);
    }

    public static void RaiseSetProgressEvent(int progress)
    {
        OnSetProgress?.Invoke(progress);
    }
}
