using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 defaultScale = Vector3.one;
    public Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1.1f);
    public float animationSpeed = 0.2f;
    public UIBounce uiBounce;

    private XRBaseInteractor hoverInteractor;
    private bool isHovering = false;

    private void OnEnable()
    {
        // Suscribirse a eventos de interacción
        var interactables = GetComponentsInChildren<XRBaseInteractable>();
        foreach (var interactable in interactables)
        {
            interactable.onHoverEntered.AddListener(OnHoverEnterXR);
            interactable.onHoverExited.AddListener(OnHoverExitXR);
        }
    }

    private void OnDisable()
    {
        // Desuscribirse de eventos de interacción
        var interactables = GetComponentsInChildren<XRBaseInteractable>();
        foreach (var interactable in interactables)
        {
            interactable.onHoverEntered.RemoveListener(OnHoverEnterXR);
            interactable.onHoverExited.RemoveListener(OnHoverExitXR);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHovering)
        {
            isHovering = true;
            StopAllCoroutines();
            StartCoroutine(AnimateScale(hoverScale));

            if (uiBounce != null)
            {
                uiBounce.StartBouncing();
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isHovering)
        {
            isHovering = false;
            StopAllCoroutines();
            StartCoroutine(AnimateScale(defaultScale));

            if(uiBounce != null)
            {
                uiBounce.StopBouncing();
            }
            
        }
    }

    public void OnHoverEnterXR(XRBaseInteractor interactor)
    {
        hoverInteractor = interactor;
        OnPointerEnter(null);
    }

    public void OnHoverExitXR(XRBaseInteractor interactor)
    {
        if (hoverInteractor == interactor)
        {
            hoverInteractor = null;
            OnPointerExit(null);
        }
    }

    private System.Collections.IEnumerator AnimateScale(Vector3 targetScale)
    {
        Vector3 initialScale = transform.localScale;
        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime / animationSpeed;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, time);
            yield return null;
        }
    }
}
