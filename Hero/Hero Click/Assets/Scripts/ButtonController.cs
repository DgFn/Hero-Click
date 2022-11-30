using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//���������� ��� ���������� ��������  
public class ButtonController : MonoBehaviour
{
    bool click = true;
    //������ ���������� �� ���������� ����� ������ � 2 ����
    public void ButtonDamage(int NumberMassive)
    {
        FindObjectOfType<PlayerTouch>().DamageX2(2);
        FindObjectOfType<PlayerTouch>().StartStopxClick();
        FindObjectOfType<ButtonTimer1>().ButtonDamageTimer(NumberMassive);
        FindObjectOfType<ManaAdd>().MinusMana(40);
        

    }
    //������ ���������� �� ���������� ����� �� � 2 ����
    public void ButtonHeroDamage(int NumberMassive)
    {
        FindObjectOfType<GunScript>().DamageX2(2);
        FindObjectOfType<GunScript>().StartStopxClick();
        FindObjectOfType<ButtonTimer>().ButtonHeroDamageTimer(NumberMassive);
        FindObjectOfType<ManaAdd>().MinusMana(40);
        
        
    }
    //������ ���������� �� ������ ���������
public void AutoClick(int NumberMassive)
    {
        FindObjectOfType<PlayerTouch>().AutoCLick(click);
        Debug.Log("peredal true");
        FindObjectOfType<ButtunTimer2>().ButtonAutoClickTimer(NumberMassive);
        FindObjectOfType<ManaAdd>().MinusMana(40);
        

    }
    //������ ���������� �� ��������� ���������� �����
    public void MultipleCash(int NumberMassive)
    {
        FindObjectOfType<GiveMyMoney>().MultipleCash(2);
        FindObjectOfType<ButtonTimer2>().ButtonMultipleCash(NumberMassive);
        FindObjectOfType<ManaAdd>().MinusMana(40);
      
    }
    // �������� ���������� ��� ���������� ������
    public void OffandOnButton(int NumberMassive)
    {
        FindObjectOfType<buttonmassive>().OffButton(NumberMassive);
    }

    public void ButtonDamgeImprovement()
    {
        FindObjectOfType<ButtonDamgeImprovement>().StartButton();
    }
    public void ButtonDamageImrovementHero()
    {
        FindObjectOfType<ButtonDamageImrovementHero>().StartButton();
    }

    public void ButtonDamageManaImprovement()
    {
        FindObjectOfType<ButtunManaImprovement>().StartButton();
    }

}
