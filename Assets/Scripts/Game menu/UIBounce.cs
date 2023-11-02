using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class UIBounce : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector3 originalPosition;
    public float bounceAmount = 10f; // Cuánto "saltará" el elemento
    public float bounceSpeed = 5f;  // Qué tan rápido "saltará"
    private bool isBouncing = false; // Controla si el elemento está saltando o no

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.localPosition;
    }

    private void Update()
    {
        if (isBouncing)
        {
            float bounce = Mathf.PingPong(Time.time * bounceSpeed, bounceAmount) - (bounceAmount / 2);
            rectTransform.localPosition = originalPosition + new Vector3(0, 0, bounce);
        }
    }

    // Método para iniciar el salto
    public void StartBouncing()
    {
        isBouncing = true;
    }

    // Método para detener el salto y regresar a la posición original
    public void StopBouncing()
    {
        isBouncing = false;
        rectTransform.localPosition = originalPosition;
    }
}
