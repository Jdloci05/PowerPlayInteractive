using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProximaInstruccion : MonoBehaviour
{
    public NPCTutorial nPCTutorial;

    public Slider slider;
    private bool passed15 = false;
    private bool passed30 = false;

    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        if (value >= 15 && !passed15)
        {
            passed15 = true;
            nPCTutorial.NuevaInstruccion(5, 3);
        }
        if (value >= 30 && !passed30)
        {
            passed30 = true;
            nPCTutorial.NuevaInstruccion(3, 2);
        }
        if(value == 100)
        {
            nPCTutorial.NuevaInstruccion(6, 4);
        }
    }
}
