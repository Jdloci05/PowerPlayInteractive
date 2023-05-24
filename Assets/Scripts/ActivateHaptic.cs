using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHaptic : MonoBehaviour
{

    public HapticInteractable haptic;
    public float timeHaptic;
    public float intensity;
    // Start is called before the first frame update
    public void Haptic()
    {
        haptic.hapticSelectExited.intensity = intensity;
        haptic.hapticSelectExited.duration = timeHaptic;
    }

    public void HapticExit()
    {
        haptic.hapticSelectExited.intensity = 0;
    }

}
