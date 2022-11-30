using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButtonAllEngl : MonoBehaviour
{
    public DialoAllEngl dialogue;

    public GameObject Button;

    public void TriggerDialog()
    {
            FindObjectOfType<DialogManagerAllEngl>().StartDialogue(dialogue);
            Button.SetActive(false);
    }

 
}
