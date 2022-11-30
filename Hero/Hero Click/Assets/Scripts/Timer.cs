using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int TimeScale = 5;
    Text TimeText;
    bool move;
    int Number;
    // Start is called before the first frame update

    public void AddTime(bool Move)
    {
        TimeText = GetComponent<Text>();
        move = Move;
        Time();
    }

    public void Time()
    {
        if (move)
        {
            StartCoroutine(Timers());
        }

    }



    IEnumerator Timers()
    {

        UpdateDisplay();
        yield return new WaitForSeconds(1);
        if (TimeScale > 1)
        {
            TimeScale = TimeScale - 1;
        }
        else
        {

            TimeScale = 5;
        }

        Time();
    }
    private void UpdateDisplay()
    {
        TimeText.text = TimeScale.ToString();
    }
}
