using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public GameObject[] objectsToMove; // Array de objetos en la escena que se mover�n
    public Transform[] newPosition; // Transform del objeto a cuya posici�n queremos mover otro objeto

    // M�todo para mover un objeto a una nueva posici�n
    public void MoveObject(int index)
    {
        if (index >= 0 && index < objectsToMove.Length)
        {
            objectsToMove[index].transform.position = newPosition[index].position;
            objectsToMove[index].transform.rotation = newPosition[index].rotation;
        }
        else
        {
            Debug.LogError("�ndice fuera de rango");
        }
    }

    // M�todo intermediario para ser llamado desde el Inspector
    public void MoveObjectFromButton(int index)
    {
        MoveObject(index);
    }
}
