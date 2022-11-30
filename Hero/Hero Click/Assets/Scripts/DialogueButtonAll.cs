using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButtonAll : MonoBehaviour
{
    public Dialog1 dialogue;

    public GameObject Button;

    public void TriggerDialog()
    {
            FindObjectOfType<DialogManagerAll>().StartDialogue(dialogue);
            Button.SetActive(false);
    }

 
}
