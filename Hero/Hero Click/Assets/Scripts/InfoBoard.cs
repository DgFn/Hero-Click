using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoard : MonoBehaviour
{
    public GameObject InfoBoardPlayer, InfoBoardHero, InfoBoardMana, InfoBoardMoney;
    int i;
    int j;
    int l;
    int m;
    public void HeroBoardActive()
    {
        if(i == 0)
        {
            i++;
            InfoBoardHero.SetActive(true);
            InfoBoardPlayer.SetActive(false);
            j = 0;
            InfoBoardMana.SetActive(false);
            l = 0;
            InfoBoardMoney.SetActive(false);
            m = 0;

        }
        else
        {
            i--;
            InfoBoardHero.SetActive(false);
        }
    }

    public void PlayerBoardActive()
    {
        if (j == 0)
        {
            j++;
            InfoBoardPlayer.SetActive(true);
            InfoBoardHero.SetActive(false);
            i = 0;
            InfoBoardMana.SetActive(false);
            l = 0;
            InfoBoardMoney.SetActive(false);
            m = 0;

        }
        else
        {
            j--;
            InfoBoardPlayer.SetActive(false);
        }
    }

    public void ManaBoardActive()
    {
        if (l == 0)
        {
            l++;
            InfoBoardMana.SetActive(true);
            InfoBoardHero.SetActive(false);
            i = 0;
            InfoBoardPlayer.SetActive(false);
            j = 0; ;
            InfoBoardMoney.SetActive(false);
            m = 0;
        }
        else
        {
            l--;
            InfoBoardMana.SetActive(false);
        }
    }

    public void MoneyBoardActive()
    {
        if (m == 0)
        {
            m++;
            InfoBoardMoney.SetActive(true);
            InfoBoardMana.SetActive(false);
            l = 0;
            InfoBoardHero.SetActive(false);
            i = 0;
            InfoBoardPlayer.SetActive(false);
            j = 0; ;
        }
        else
        {
            m--;
            InfoBoardMoney.SetActive(false);
        }
    }
}
