using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public GameObject[] objectsToMove; // Array de objetos en la escena que se moverán
    public Transform[] newPosition; // Transform del objeto a cuya posición queremos mover otro objeto

    // Método para mover un objeto a una nueva posición
    public void MoveObject(int index)
    {
        if (index >= 0 && index < objectsToMove.Length)
        {
            objectsToMove[index].transform.position = newPosition[index].position;
            objectsToMove[index].transform.rotation = newPosition[index].rotation;
        }
        else
        {
            Debug.LogError("Índice fuera de rango");
        }
    }

    // Método intermediario para ser llamado desde el Inspector
    public void MoveObjectFromButton(int index)
    {
        MoveObject(index);
    }
}
