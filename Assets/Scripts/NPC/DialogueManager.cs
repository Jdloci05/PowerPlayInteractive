using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Referencia al componente de texto de UI
    [TextArea] public string texto;
    public float typingSpeed = 0.05f; // Velocidad de tipeo en segundos por carácter

    private void Start()
    {
        // Puedes iniciar un diálogo aquí como ejemplo
        StartCoroutine(TypeSentence(texto));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
