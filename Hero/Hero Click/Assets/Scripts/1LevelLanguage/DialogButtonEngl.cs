using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogButtonEngl : MonoBehaviour
{
    public DialogEngl dialogue;
     public GameObject Button;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManagerEngl>().StartDialogue(dialogue);
        Button.SetActive(false);
    }
}
