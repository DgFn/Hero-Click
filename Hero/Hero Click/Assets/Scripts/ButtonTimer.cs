using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTimer : MonoBehaviour
{
    [Tooltip("Our Button Timer")]
    public GameObject CircleTimer ;

    Text TimeText;
    float TimeScale = 0;


    private void Update()
    {
        CircleTimer.GetComponent<Image>().fillAmount = TimeScale / 10;
    }

    public void ButtonHeroDamageTimer(int NumberMassive)
    {
        FindObjectOfType<buttonmassive>().StartFire(1);
        StartCoroutine(Timers());
        IEnumerator Timers()
        {
            CircleTimer.SetActive(true);
            yield return new WaitForSeconds(1);
            if (TimeScale < 10)
            {
               
                TimeScale = TimeScale + 1;
                StartCoroutine(Timers());
            }
            else
            {
                FindObjectOfType<buttonmassive>().StopFire(NumberMassive, 1);
                CircleTimer.SetActive(false);
                TimeScale = 60;
                StartCoroutine(TimersWait(NumberMassive)); 
            }
        }
    }

    IEnumerator TimersWait(int NumberMassive)
   {
    TimeText = GetComponentInChildren<Text>();
        TimeText.text = TimeScale.ToString();
        yield return new WaitForSeconds(1);
        if(TimeScale > 1)
        {
            TimeScale = TimeScale - 1;
            TimeText.enabled = true;
            TimeText.text = TimeScale.ToString();
            StartCoroutine(TimersWait(NumberMassive));
        }
        else
        {
            FindObjectOfType<buttonmassive>().OnButton(NumberMassive);
            TimeText.enabled = false;
            TimeScale = 0;
        }
    }



}