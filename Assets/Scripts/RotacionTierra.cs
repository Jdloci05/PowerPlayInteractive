using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionTierra : MonoBehaviour
{
    public float velocidadRotacion = 10.0f; // Velocidad de rotación en grados por segundo

    // Update se llama una vez por frame
    void Update()
    {
        // Rotar el objeto alrededor del eje Y
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}
