using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCTutorial : MonoBehaviour
{
    public Transform playerPos;
    private Vector3 currentPos;
    [Header("NPC")]
    public GameObject NPC;
    public NavMeshAgent agent;

    [Header("Rutas")]
    public GameObject[] paths;
    public GameObject zona;

    [Header("Dialogos")]
    public AudioSource audioSource;
    public AudioClip[] dialogos;
    public GameObject dialogoInicial;
    public GameObject[] dialogosInstrucciones;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        InicioRuta();
    }

    void Update()
    {
        currentPos = playerPos.position;
    }

    public void InicioRuta()
    {
        StartCoroutine(TerminarDialogo(dialogos[0]));
    }

    IEnumerator TerminarDialogo(AudioClip dialogo)
    {
        dialogoInicial.SetActive(true);
        audioSource.clip = dialogos[0];
        audioSource.Play();

        yield return new WaitForSeconds(dialogo.length);
        dialogoInicial.SetActive(false);
        
        dialogosInstrucciones[0].SetActive(true);
        agent.SetDestination(paths[0].transform.position);
        StartCoroutine(LlegarAlDestino(1, 0));

        yield return new WaitForSeconds(dialogos[1].length);
        zona.SetActive(true);
        dialogosInstrucciones[0].SetActive(false);
    }

    public void NuevaInstruccion(int dialogIndex, int currentNode)
    {
        dialogosInstrucciones[currentNode-1].SetActive(false);
        StopAllCoroutines();
        agent.SetDestination(paths[currentNode].transform.position);
        StartCoroutine(LlegarAlDestino(dialogIndex, currentNode));
    }

    IEnumerator LlegarAlDestino(int dialogoIndex, int currentNode)
    {
        while (agent.pathPending || agent.remainingDistance > 0.1f)
        {
            yield return null;
        }
        NPC.transform.LookAt(currentPos);
        dialogosInstrucciones[currentNode].SetActive(true);
        audioSource.clip = dialogos[dialogoIndex];
        audioSource.Play();
    }
}
