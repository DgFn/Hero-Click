using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDragon : MonoBehaviour
{
    public GameObject Dragon, Fire;

    public void DragobKus()
    {
        Dragon.SetActive(true);
        StartCoroutine(OffButton());
        StartCoroutine(OffDragon());
    }

    IEnumerator OffButton()
    {
        yield return new WaitForSeconds(1200);
        FindObjectOfType<buttonmassive>().OnButton(5);
    }

    IEnumerator OffDragon()
    {

        yield return new WaitForSeconds((float)0.5);
        Fire.SetActive(true);
        FindObjectOfType<ManaAdd>().DragonMana(100);
        yield return new WaitForSeconds((float)0.5);
        Dragon.SetActive(false);
        yield return new WaitForSeconds(1);
        Fire.SetActive(false);
    }
  
    
}
