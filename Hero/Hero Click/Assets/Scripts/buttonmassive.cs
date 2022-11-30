using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonmassive : MonoBehaviour
{
    public List<GameObject> List;
    public List<GameObject> FireList;
    int iFire;

    public void ManaCheck(float Mana)
    {
        if(Mana < 40)
        {
            List[0].GetComponent<Button>().interactable = false;
            List[1].GetComponent<Button>().interactable = false;
            List[2].GetComponent<Button>().interactable = false;
            List[3].GetComponent<Button>().interactable = false;
        }
        else
        {
            List[0].GetComponent<Button>().interactable = true;
            List[1].GetComponent<Button>().interactable = true;
            List[2].GetComponent<Button>().interactable = true;
            List[3].GetComponent<Button>().interactable = true;
        }
    }

    public void OffButton(int NumberMassive)
    {
        Debug.Log("alo");
        List[NumberMassive].GetComponent<Image>().color = new Color32(97, 80, 80, 255);
        List[NumberMassive].GetComponent<Button>().enabled = false;
    }

    public void OnButton(int NumberMassive)
    {
        List[NumberMassive].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        List[NumberMassive].GetComponent<Button>().enabled = true;

    }

    public void StartFire(int i)
    {
        iFire += i; 
        if(iFire == 4)
        {
            FireList[0].SetActive(true);
            FireList[1].SetActive(true);
            FireList[2].SetActive(true);
            FireList[3].SetActive(true);
        }
    }

    public void StopFire(int NumberMassive, int i)
    {
        iFire -= i;
        FireList[NumberMassive].SetActive(false);
    }

}
