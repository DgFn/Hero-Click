using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonDamgeImprovement : MonoBehaviour
{
    public GameObject ButtonImprovement;
    [SerializeField]  int Level = 0;
    [SerializeField]  int addLevel = 0;
    int cash = 10;
    int cashx = 100;
    int cashk = 10;
    [SerializeField]int Levelx = 9;
    int CheckNumber = 10;
    Text textCash;
    bool move = false;
   

    public void Getsave(int cashDam1, int cashxDam1, int Level1, int Levelx1, int ChechNum1)
    {
        cash = cashDam1;
        cashx = cashxDam1;
        Level = Level1;
        Levelx = Levelx1;
        CheckNumber = ChechNum1;
        AddCash();
        CashLevel10();
    }

    public void Start()
    {
        textCash = GetComponentInChildren<Text>();
        textCash.text = cashk.ToString();
    }

    private void Update()
    {
        string shortScaleNum = PolyLabs.ShortScale.ParseFloat(cashk);

        textCash.text = shortScaleNum.ToString();
    }

    public void UpdateButton(float Money)
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

    public void SetSave(bool save)
    {
        move = save;
        if(move)
        {
            FindObjectOfType<PlayerPrefsController>().SaveNextDamageLevel(cash, cashx, Level, Levelx, CheckNumber);
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
        FindObjectOfType<PlayerTouch>().xDamage(1);
    }

    public void AddCash()
    {
        if(Levelx > Level)
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
        cash = cash + 10;
        cashx = cashx + 100;
            CheckNumber += 10;
            cashk = cash;
            FindObjectOfType<PlayerTouch>().xcash(5);
            textCash.text = cashk.ToString();
        }
        
    }

 

    public void TakeMoney()
    {
        FindObjectOfType<GiveMyMoney>().TakeMoney(cashk);
    }
    public void UpdateDisplay()
    {
            textCash.text = cashk.ToString();
    }

}
