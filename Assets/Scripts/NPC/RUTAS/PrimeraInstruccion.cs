using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeraInstruccion : MonoBehaviour
{
    public NPCTutorial nPCTutorial;
    public int dialogoIndex = 2;
    public int nextNode = 1;
    public GameObject zona;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            nPCTutorial.NuevaInstruccion(dialogoIndex, nextNode);
            zona.SetActive(false);
        }
    }
}
