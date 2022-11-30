using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDamageImrovementHero : MonoBehaviour
{
    public GameObject ButtonImprovement;
    [SerializeField] int Level = 0;
    [SerializeField] int addLevel = 0;
    int cash = 20;
    int cashx = 200;
    int cashk = 20;
    [SerializeField] int Levelx = 9;
    int CheckNumber = 10;
    Text textCash;
    bool move = false;

    public void Getsave(int cashdam2, int cashxDam2, int Level2, int Levelx2, int ChechNum2)
    {
        cash = cashdam2;
        cashx = cashxDam2;
        Level = Level2;
        Levelx = Levelx2;
        CheckNumber = ChechNum2;
        AddCash();
        CashLevel10();
    }

    private void Start()
    {
        textCash = GetComponentInChildren<Text>();
        textCash.text = cashk.ToString();
    }

    private void Update()
    {
        string shortScaleNum = PolyLabs.ShortScale.ParseFloat(cashk);
        textCash.text = shortScaleNum.ToString();
    }
    public void Update(float Money)
    {
        if (Money >= cashk)
        {
            ButtonImprovement.GetComponent<Button>().interactable = true;
        }
        else
        {
            ButtonImprovement.GetComponent<Button>().interactable = false;
        }
    }

    public void GetSaveHero(bool save)
    {
        move = save;
        if (move)
        {
            FindObjectOfType<PlayerPrefsController>().SaveNextHeroLevel(cash, cashx, Level, Levelx, CheckNumber);
            move = false;
        }

    }


    public void StartButton()
    {

        AddCash();
        Level++;
        TakeMoney();
        CashLevel10();
        CheckCash();
        UpdateDisplay();
        FindObjectOfType<GunScript>().xDamage(5);
    }

    public void AddCash()
    {
        if (Levelx > Level)
        {
            cashk = cash;
            textCash.text = cashk.ToString();
        }

    }

    public void CashLevel10()
    {
        if (Level == Levelx)
        {
            cashk = cashx;
            textCash.text = cashk.ToString();
        }
    }

    private void CheckCash()
    {
        if (CheckNumber == Level)
        {
            Levelx = Levelx + 10;
            cash = cash + 20;
            cashx = cashx + 200;
            CheckNumber += 10;
            cashk = cash;
            FindObjectOfType<GunScript>().xcash(1);
            textCash.text = cashk.ToString();
            
        }

    }



    public void TakeMoney()
    {
        FindObjectOfType<GiveMyMoney>().TakeMoney(cashk);
    }
    private void UpdateDisplay()
    {
        textCash.text = cashk.ToString();
    }

}