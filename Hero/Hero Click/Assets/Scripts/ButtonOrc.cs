using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOrc : MonoBehaviour
{
    public GameObject OrcButton, OrcKliv;

    public void OrcOn()
    {
        OrcKliv.SetActive(true);
        StartCoroutine(OrcAttack());
        StartCoroutine(ButtonOn()); 
    }

    IEnumerator ButtonOn()
    {
        yield return new WaitForSeconds(600);
        FindObjectOfType<buttonmassive>().OnButton(4);
    }

    IEnumerator OrcAttack()
    {
        yield return new WaitForSeconds((float)0.5);
        FindObjectOfType<HPSLider>().OrcButton();
        yield return new WaitForSeconds((float)0.5);
        OrcKliv.SetActive(false);
    }
}
