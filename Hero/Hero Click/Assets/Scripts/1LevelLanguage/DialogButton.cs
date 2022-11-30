using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogButton : MonoBehaviour
{
    public Dialog dialogue;
     public GameObject Button;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
        Button.SetActive(false);
    }
}
