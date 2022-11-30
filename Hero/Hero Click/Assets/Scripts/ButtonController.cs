using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Контроллер для управления кнопками  
public class ButtonController : MonoBehaviour
{
    bool click = true;
    //Кнопка отвечающая за увеличения урона игрока в 2 раза
    public void ButtonDamage(int NumberMassive)
    {
        FindObjectOfType<PlayerTouch>().DamageX2(2);
        FindObjectOfType<PlayerTouch>().StartStopxClick();
        FindObjectOfType<ButtonTimer1>().ButtonDamageTimer(NumberMassive);
        FindObjectOfType<ManaAdd>().MinusMana(40);
        

    }
    //Кнопка отвечающая за увеличения урона ГГ в 2 раза
    public void ButtonHeroDamage(int NumberMassive)
    {
        FindObjectOfType<GunScript>().DamageX2(2);
        FindObjectOfType<GunScript>().StartStopxClick();
        FindObjectOfType<ButtonTimer>().ButtonHeroDamageTimer(NumberMassive);
        FindObjectOfType<ManaAdd>().MinusMana(40);
        
        
    }
    //Кнопка отвечающая за запуск автоклика
public void AutoClick(int NumberMassive)
    {
        FindObjectOfType<PlayerTouch>().AutoCLick(click);
        Debug.Log("peredal true");
        FindObjectOfType<ButtunTimer2>().ButtonAutoClickTimer(NumberMassive);
        FindObjectOfType<ManaAdd>().MinusMana(40);
        

    }
    //Кнопка отвечающая за временное увеличение денег
    public void MultipleCash(int NumberMassive)
    {
        FindObjectOfType<GiveMyMoney>().MultipleCash(2);
        FindObjectOfType<ButtonTimer2>().ButtonMultipleCash(NumberMassive);
        FindObjectOfType<ManaAdd>().MinusMana(40);
      
    }
    // Передает информацию для отключения кнопки
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
