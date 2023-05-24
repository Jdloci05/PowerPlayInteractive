using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelProgress : MonoBehaviour
{
    public int puntos;
    public Slider slider;


    public ProgressBar progressBar;

    public GameObject mision;
    // Start is called before the first frame update

    public void Enter()
    {
        slider.value += puntos;
        mision.SetActive(true);
    }

    public void Exit()
    {
        slider.value -= puntos;
        mision.SetActive(false);
    }


}
