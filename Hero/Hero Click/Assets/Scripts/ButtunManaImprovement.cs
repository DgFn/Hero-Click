using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtunManaImprovement : MonoBehaviour
{
    public GameObject ButtonManaImprovement;
    [SerializeField] int Level = 0;
    [SerializeField] int addLevel = 0;
    int cash = 100;
    int cashx = 1000;
    int cashk = 100;
    [SerializeField] int Levelx = 9;
    int CheckNumber = 10;
    Text textCash;
    bool move = false;
    public void Getsave(int cashdam3, int cashxDam3, int Level3, int Levelx3, int ChechNum3)
    {
        cash = cashdam3;
        cashx = cashxDam3;
        Level = Level3;
        Levelx = Levelx3;
        CheckNumber = ChechNum3;
        AddCash();
        CashLevel10();
    }

    private void Start()
    {
        textCash = GetComponentInChildren<Text>();
       
        
    }

    private void Update()
    {
        string shortScaleNum = PolyLabs.ShortScale.ParseFloat(cashk);

        textCash.text = shortScaleNum.ToString();
        if (Level == 30)
        {

            textCash.text = "Max";
            ButtonManaImprovement.GetComponent<Button>().enabled = false;

        }
    }

    public void Update(float Money)
    {
        if (Money >= cashk)
        {
            ButtonManaImprovement.GetComponent<Button>().interactable = true;
        }
        else
        {
            ButtonManaImprovement.GetComponent<Button>().interactable = false;
        }
    }
   
    public void GetSaveMana(bool save)
    {
        move = save;
        if (move)
        {
            FindObjectOfType<PlayerPrefsController>().SaveNextManaLevel(cash, cashx, Level, Levelx, CheckNumber);
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
        MaxMana();
        
        FindObjectOfType<ManaAdd>().TakeMana(1);
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
            cash = cash + 100;
            cashx = cashx + 1000;
            CheckNumber += 10;
            cashk = cash;
            textCash.text = cashk.ToString();
        }

    }

    private void MaxMana()
    {
        if(Level == 30)
        {

            textCash.text = "Max";
            ButtonManaImprovement.GetComponent<Button>().enabled = false;
           
        }
    }



    public void TakeMoney()
    {
        FindObjectOfType<GiveMyMoney>().TakeMoney(cashk);
    }
    private void UpdateDisplay()
    {
        
    }

}

