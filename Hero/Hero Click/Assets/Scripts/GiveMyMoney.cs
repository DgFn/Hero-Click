using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveMyMoney : MonoBehaviour
{
    
    [SerializeField] float Money;
    Text MoneyText;
    float Mony = 1;
    bool move = false;
    //�������� �����, � ��������� ������� ��� ������ ������� �����
    public void Start()
    {
        MoneyText = GetComponent<Text>();
        UpdateDisplay();
        UpdateButton();
    }

    public void Update()
    {
        UpdateButton();
        string shortScaleNum = PolyLabs.ShortScale.ParseFloat(Money);

        MoneyText.text = shortScaleNum.ToString();
    }

    public void UpdateSave(bool save)
    {
        move = save;
        if (save)
        {
            FindObjectOfType<PlayerPrefsController>().SaveNextMoney(Money);
            move = false;
        }
    }
    private void UpdateButton()
    {
        FindObjectOfType<ButtonDamgeImprovement>().UpdateButton(Money);
        FindObjectOfType<ButtonDamageImrovementHero>().Update(Money);
        FindObjectOfType<ButtunManaImprovement>().Update(Money);
    }
    //���������� ������ � ������ �����
    private void UpdateDisplay()
    {
        if(Money >= 0)
        {
         MoneyText.text = Money.ToString();
        }
        
    }
    // �������� ����������, � ���������, ���� ��� �����
    public void MultipleCash(int xMoney)
    {
      Mony = xMoney;
        StartCoroutine(DestroyMuptipleCash());
    }
    // ����� �����
    public void RewardMoney(int cash)
    {
        Money *= cash;
    }
    public void AddMoney(float cash)
    {
        Money += cash * Mony;
        UpdateDisplay();
        UpdateButton();
    }
    // ������������� ���������� �����, ����� 10 ���
    IEnumerator DestroyMuptipleCash()
    {
        yield return new WaitForSeconds(10);
        Mony = 1;
    }

    public void TakeMoney(int cash)
    {
        if(Money >= cash)
        {
            Money = Money - cash;
            UpdateDisplay();
            UpdateButton();
        }
       
       
    }
}
