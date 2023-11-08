using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using System.Collections;

public class UIButtonFilledWithBorad : XRBaseInteractable, IPointerDownHandler, IPointerUpHandler
{
    public Image fillImage;
    private float holdTime = 3f;
    private float holdTimer;
    private bool isHeld;

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(StartHold);
        selectExited.AddListener(EndHold);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(StartHold);
        selectExited.RemoveListener(EndHold);
    }

    // Eventos de XR Interaction Toolkit
    private void StartHold(SelectEnterEventArgs arg) => StartHoldRoutine();

    private void EndHold(SelectExitEventArgs arg) => EndHoldRoutine();

    // Eventos del puntero para interacciones con el mouse
    public void OnPointerDown(PointerEventData eventData) => StartHoldRoutine();

    public void OnPointerUp(PointerEventData eventData) => EndHoldRoutine();

    // Rutinas de inicio y fin de la sujeción
    private void StartHoldRoutine()
    {
        if (!isHeld) // Evitar que se inicie más de una vez
        {
            isHeld = true;
            holdTimer = 0f;
            StartCoroutine(UpdateFill());
        }
    }

    private void EndHoldRoutine()
    {
        if (isHeld) // Solo detener si está en progreso
        {
            isHeld = false;
            holdTimer = 0f;
            fillImage.fillAmount = 0f; // Restablecer la animación de la línea
            StopAllCoroutines(); // Asegúrate de detener la corutina si se está ejecutando
        }
    }

    private IEnumerator UpdateFill()
    {
        while (isHeld && holdTimer < holdTime)
        {
            holdTimer += Time.deltaTime;
            fillImage.fillAmount = holdTimer / holdTime;
            yield return null;
        }
        if (holdTimer >= holdTime)
        {
            // Ejecutar la acción después de que se complete el hold
            OnHoldComplete();
            isHeld = false; // Restablecer el estado
        }
    }

    private void OnHoldComplete()
    {
        // Acción a realizar después de completar el hold
        Debug.Log("Hold completo!");
    }
}
