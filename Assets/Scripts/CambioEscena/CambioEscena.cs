using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    // Variable pública para indicar la escena a cargar (asegúrate de asignar el índice correcto en el Inspector)
    public int sceneToLoad;

    // Método para cambiar de escena
    public void CambiarEscena()
    {
        // Asegurarse de que el índice de escena esté dentro de los límites
        if (sceneToLoad >= 0 && sceneToLoad < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Índice de escena no válido. Asegúrate de que el valor de 'sceneToLoad' sea correcto.");
        }
    }
}
