using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawn : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2;
    public GameObject menu;
    public bool Init = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Init)
        {
            Invoke("Appear", 0.1f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;
    }

    public void Appear()
    {
        menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
    }
}
