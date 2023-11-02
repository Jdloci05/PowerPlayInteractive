using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    // Variable p�blica para indicar la escena a cargar (aseg�rate de asignar el �ndice correcto en el Inspector)
    public int sceneToLoad;

    // M�todo para cambiar de escena
    public void CambiarEscena()
    {
        // Asegurarse de que el �ndice de escena est� dentro de los l�mites
        if (sceneToLoad >= 0 && sceneToLoad < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("�ndice de escena no v�lido. Aseg�rate de que el valor de 'sceneToLoad' sea correcto.");
        }
    }
}
