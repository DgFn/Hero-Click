using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerTouch : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    public GameObject clickParent, clickTextPrefab;
    private clickDamage[] clickTextPool = new clickDamage[150];
    private int clickNum;
    float Damage =1;
    float Damagex = 1;
    bool Click = false;
    int Damagex2 = 1;
    int cashx = 25;
    int cashx1000 = 50;
 [SerializeField]   float MonyCLick;
 [SerializeField]   float MonyCLick100;
    public Text InfoBoardPlayer, Money1000, Money50;
    bool move;
    int language = 0;


    private void Start()
    {
        StartMassive();
        StartCoroutine(CheckClick());
        StartCoroutine(CheckClick1000());
    }

    public void dUpdate(bool save)
    {
        move = save;
        if(move)
        {
            FindObjectOfType<PlayerPrefsController>().SaveTapDamage(Damagex);
            FindObjectOfType<PlayerPrefsController>().SaveMonyTap(cashx,cashx1000);
            move = false;
        }
    }

    public void GetSave(float Damtap, int Tap500, int Tap1000)
    {
        Damage = Damtap;
        Damagex = Damage;
        cashx = Tap500;
        cashx1000 = Tap1000;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        FindObjectOfType<GetDamage>().AddScore(Damagex);
        FindObjectOfType<HPSLider>().MinusHP(Damagex);
        FindObjectOfType<Enemy>().GetDamage();
        MonyCLick500();
        MonyCLick1000();
        GiveDamage();
    }

    private void Update()
    {
        if(language == 0)
        {
            string shortScaleNum = PolyLabs.ShortScale.ParseFloat(Damagex);
            InfoBoardPlayer.text = "Tap Damage: " + shortScaleNum.ToString();
            string shortScaleNum1 = PolyLabs.ShortScale.ParseFloat(cashx1000);  
            Money1000.text = "Coins for 1000 clicks: " + shortScaleNum1.ToString();
            string shortScaleNum2 = PolyLabs.ShortScale.ParseFloat(cashx);
            Money50.text = "Coins for 500 clicks: " + shortScaleNum2.ToString();
        }
        else
        {
            string shortScaleNum = PolyLabs.ShortScale.ParseFloat(Damagex);
            InfoBoardPlayer.text = "Твой урон от тапа: " + shortScaleNum.ToString();
            string shortScaleNum1 = PolyLabs.ShortScale.ParseFloat(cashx1000);
            Money1000.text = "Монеты за 1000 тапов: " + shortScaleNum1.ToString();
            string shortScaleNum2 = PolyLabs.ShortScale.ParseFloat(cashx);
            Money50.text = "Монеты за 500 тапов: " + shortScaleNum2.ToString();
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

    //Запускает массив с уроном, который будет вылетать
    private void StartMassive()
    {
        for (int i = 0; i < clickTextPool.Length; i++)
        {
            clickTextPool[i] = Instantiate(clickTextPrefab, clickParent.transform).GetComponent<clickDamage>();
        }
    }
    // Урон игрока
    public void xDamage(float plusDamage)
    {
        if(Damagex2 == 1)
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

    public void xcash(int cash)
    {
        cashx += cash;
      cashx1000 += cash;
    }

public void MonyCLick500()
    {
        if(!(MonyCLick == 500))
        {
            MonyCLick += 1;
        }
        else
        {
            MonyCLick = 0;
            FindObjectOfType<GiveMyMoney>().AddMoney(cashx);
        }
    }
    IEnumerator CheckClick()
    {
        yield return new WaitForSeconds(120);
        MonyCLick = 0;
        StartCoroutine(CheckClick());

    }
    public void MonyCLick1000()
    {
        if (!(MonyCLick100 == 1000))
        {
            MonyCLick100 += 1;
        }
        else
        {
            MonyCLick100 = 0;
            FindObjectOfType<GiveMyMoney>().AddMoney(cashx1000);
        }
    }

    IEnumerator CheckClick1000()
    {
        yield return new WaitForSeconds(180);
        MonyCLick = 0;
        StartCoroutine(CheckClick());

    }



    public void DamageX2(int Damage2)
    {
        Damagex2 = Damage2;
        if (Damagex2 == 2)
        {
            Damagex = Damage * Damagex2;
        }
    }
    // Отвечает за появления урона
    public void GiveDamage()
    {
        string shortScaleDam = PolyLabs.ShortScale.ParseFloat(Damagex);
        clickTextPool[clickNum].StartMotion(shortScaleDam);
       if( clickNum == clickTextPool.Length - 1)
        {
            clickNum = 0;
        }
       else
        {   
            clickNum++;
        }

    }
    // Проверка, нужен ли автоклик или нет
    public void AutoCLick(bool click)
    {
        Click = click;
        StartCoroutine(StopAutoClick());
    }
    // Отвечает за автоклик, при перетаскивание запускает клик
    public void OnDrag(PointerEventData pointerEventData)
    {
        if(Click)
        {
            OnPointerClick(pointerEventData);
            Debug.Log("rabotaet");
        }

    }
    // Через 5 секунд отключает автоклик
    IEnumerator StopAutoClick()
    {
        yield return new WaitForSeconds(10);
        Click = false;
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
        Click = false;
        Damagex2 = 1;
        Damagex = Damage;
    }
}
