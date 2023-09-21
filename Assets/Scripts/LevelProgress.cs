using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelProgress : MonoBehaviour
{
    public int puntos;
    public Slider slider;

    public GameObject mision;

    public void Enter()
    {
        // Use the public methods to raise the events
        ProgressBar.RaiseSetProgressEvent((int)slider.value + puntos);
        mision.SetActive(true);
    }

    public void Exit()
    {
        // Use the public methods to raise the events
        ProgressBar.RaiseSetProgressEvent((int)slider.value - puntos);
        mision.SetActive(false);
    }

}
