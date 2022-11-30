using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    int Money = 0;
    float Damage = 5;
    int cash = 1;
    int Damagex2 = 1;
    float Damagex = 5;
    public Text InfoText, MoneyText;
    bool move = false;
    int language = 0;
    AudioSource Audio;
    // При касание объектов наносится урон и запускается счетчик монет

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
    public void SetSave(float DamHero, int cashHero)
    {
        cash = cashHero;
        Damage = DamHero;
        Damagex = Damage;
    }

    public void GetSave(bool save)
    {
        move = save;
        if(move)
        {
            FindObjectOfType<PlayerPrefsController>().SaveHeroDamageMoney(Damagex, cash);
            move = false;
        }
    }

    private void Update()
    {
        if(language == 0)
        {
            string shortScaleNum = PolyLabs.ShortScale.ParseFloat(Damagex);
            InfoText.text = "Damage Osk: " + shortScaleNum.ToString();
            string shortScaleNum1 = PolyLabs.ShortScale.ParseFloat(cash);
            MoneyText.text = "Coins for 5 hits: " + shortScaleNum1.ToString();
        }
        else
        {
            string shortScaleNum = PolyLabs.ShortScale.ParseFloat(Damagex);
            InfoText.text = "Урон Оска: " + shortScaleNum.ToString();

            string shortScaleNum1 = PolyLabs.ShortScale.ParseFloat(cash);
            MoneyText.text = "Монеты за 5 ударов: " + shortScaleNum1.ToString();
        }

          
    }

    public void UpdateLang(int Language)
    {

        if (Language == 0)
        {
            language = 0;
        }
        else
        {
            language = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D othercollider)
    {
        Audio.Play();
        FindObjectOfType<Enemy>().GetDamage();
    }
    private void OnTriggerExit2D(Collider2D othercollider)
    {
        GiveDamage();
       
        AddCash();
        FindObjectOfType<HPSLider>().MinusHP(Damagex);
    }
     
    public void xcash(int cashx)
    {
        cash += cashx;
    }
   
    // Счетчик для монет
    public void AddCash()
    {
        if (Money == 4)
        {  
          FindObjectOfType<GiveMyMoney>().AddMoney(cash);
            Money = 0;
        }
        else
        {
            Money++;
        }
    }
    // Увеличение урона героя
    public void xDamage(float plusDamage)
    {
        if (Damagex2 == 1)
        {
            Damage = Damage + plusDamage;
            Damagex = Damage;
            
        }
        else
        {
            Damage = Damage + plusDamage;
            DamageX2(2);
        }
    }

    public void DamageX2(int Damage2)
    {
        Damagex2 = Damage2;
        if(Damagex2 == 2)
        {
            Damagex = Damage * Damagex2;
        }
    }
    public void GiveDamage()
    { 
        FindObjectOfType<GetDamage>().AddScore(Damagex);
    }

    public void StartStopxClick()
    {
        StartCoroutine(StopXCLick());
    }
    IEnumerator StopXCLick()
    {
        yield return new WaitForSeconds(10);
        Damagex2 = 1;
        Damagex = Damage;
    }

    public void StopAll()
    {
        StopAllCoroutines();
        Damagex2 = 1;
        Damagex = Damage;
    }

}
