using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSnapZone : MonoBehaviour
{
    public MeshRenderer snapZone1;
    public MeshRenderer snapZone2;

    bool ShowSnapZone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShowSnapZone == true)
        {
            snapZone1.enabled = true;
            snapZone2.enabled = true;
        }
        else if(ShowSnapZone == false)
        {
            snapZone1.enabled = false;
            snapZone2.enabled = false;
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("SnapZone"))
        {
            ShowSnapZone = false;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("SnapZone"))
        {
            ShowSnapZone = true;
        }
    }

    public void SelectObject()
    {
        ShowSnapZone = true;       
    }

    public void ExitSelectObject()
    {
        ShowSnapZone = false;
    }

}
