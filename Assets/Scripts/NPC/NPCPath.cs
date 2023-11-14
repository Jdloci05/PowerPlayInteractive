using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCPath : MonoBehaviour
{
    //Variables p�blicas
    [Tooltip("Agregar� a la lista de Path las posiciones exactas de todos los hijos.")]
    private bool useChildPaths = true;
    public bool invertPath, stopOnEnd;
    public int indexChildrenPaths;
    public List<Vector3> paths;
    Vector3 initialpos;
    Quaternion initialrot;
    public float speed = 1.5f, rotationspeed = 5;
    public UnityEvent onStart, onStop, onRestart;

    //Variables privadas
    [HideInInspector]public bool walk; //flag de errores de ruteo
    int index = 0; //indice de ruta
    [HideInInspector] public Vector3 nextPathhpoint; //direccion de movimiento
    public Animator anim;

    void Start()
    {
        useChildPaths = true;
        initialpos = transform.position;
        initialrot = transform.rotation;
        if (paths.Count > 0) { walk = true; nextPathhpoint = paths[index]; paths.Insert(0, gameObject.transform.position); }
        if(useChildPaths) { SearchChildTransform(); }
        if (invertPath) { Vector3[] myArray = paths.ToArray(); Array.Reverse(myArray); paths = new List<Vector3>(myArray); }
        onStart.Invoke();
    }
    void Update()
    {
        
        if (walk)
        {
            if (anim != null) { if (!anim.GetBool("walk")) { anim.SetBool("walk", true); } }
            //smooth position
            transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPathhpoint, speed * Time.deltaTime);
            //smooth rotation
            /**/
            if ((nextPathhpoint - transform.position) != Vector3.zero)
            {
                var targetRotation = Quaternion.LookRotation(nextPathhpoint - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationspeed * Time.deltaTime);
            }
            //cambio de paht
            if (gameObject.transform.position == nextPathhpoint)
            {
                if (stopOnEnd) { walk = (index >= paths.Count - 1) ? false : true; if (!walk) { onStop.Invoke(); } }
                index = (index >= paths.Count - 1) ? 0 : index + 1;
                nextPathhpoint = paths[index];
            }
        } else {
            if (anim != null) { if (anim.GetBool("walk")) { anim.SetBool("walk", false); } } 
        }
    }
    void SearchChildTransform()
    {
        //adquiere los transform de los hijos
        GameObject path = transform.GetChild(indexChildrenPaths).gameObject;
        if (path == null) { Debug.LogError("Seguro que este NPC se debe mover?"); }
        Transform[] child = path.transform.GetComponentsInChildren<Transform>();
        foreach(Transform trans in child)
        {
            //los a�ade a la ruta
            paths.Add(trans.position);
        }
        //setea el inicio
        walk = true;
        nextPathhpoint = paths[index];
        //paths.Insert(0, gameObject.transform.position);
    }

    public void Stop()
    {
        speed = 0f;
        walk = false;
    }
    public void Run()
    {
        speed = 1.5f;
        walk = true;
    }
    public void Run(float value = 1.5f)
    {
        speed = value;
        walk = true;
    }
    public void Restart(bool detenido = false)
    {
        Debug.Log("ruta de "+gameObject.name + " reseteada.", transform);
        transform.position = initialpos;
        transform.rotation = initialrot;
        if (anim != null) { anim.Play(0); }
        if (paths.Count>0) { nextPathhpoint = paths[0]; }
        index = 0;
        Run();
        if (detenido)
        {
            Stop();
        }
        onRestart.Invoke();
    }

    public void ResetPath()
    {
        walk = true;
        if (speed <= 0) { Run(); }
        nextPathhpoint = paths[0];
        index = 0;
    }
}
