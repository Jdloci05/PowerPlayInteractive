using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personalizacion : MonoBehaviour
{
    public SkinnedMeshRenderer left;
    public SkinnedMeshRenderer right;
    public MaterialesSO materialSO;

    public void CambiarColor(int color)
    {
        left.sharedMaterial = materialSO.material[color];
        right.sharedMaterial = materialSO.material[color];
    }
}
