using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSLider : MonoBehaviour
{
    [SerializeField] float HP;
    public GameObject ButtuonNextScene;
    public GameObject HPSlider, Osk, ZoneTouch;
    bool movesave;
    Text HPText;
    public InterAD interAD;
    public int Level;
    void Start()
    { 
        if(!(Level == 9))
        {
            HPSlider.SetActive(true);
            ButtuonNextScene.SetActive(false);
            HPText = GetComponentInChildren<Text>();
            HPText.text = HP.ToString();
            GetComponent<Slider>().value = HP;
            Level2();
        }
        else
        {
            Level2();
            HPText = GetComponentInChildren<Text>();
            FindObjectOfType<PlayerPrefsController>().InfStartHP(9);
        }
      
    }

    public void OrcButton()
    {
        HP /= 2;
    }

    private void Update()
    {
        string shortScaleNum = PolyLabs.ShortScale.ParseFloat(HP);
        HPText.text = shortScaleNum.ToString();
    }
    public void MinusHP(float Damage)
    {
        if(HP > 0)
        {
            HP -= Damage;
            if(HP <= 0 )
            {
                HP = 0;
            }
            GetComponent<Slider>().value = HP;
            HPText.text = HP.ToString();
        }
        else
        {
            if (!(Level == 9))
            {
                HPText.enabled = false;
                movesave = true;
                FindObjectOfType<PlayerTouch>().StopAll();
                FindObjectOfType<GunScript>().StopAll();
                FindObjectOfType<GiveMyMoney>().UpdateSave(movesave);
                FindObjectOfType<ButtonDamgeImprovement>().SetSave(movesave);
                FindObjectOfType<ButtonDamageImrovementHero>().GetSaveHero(movesave);
                FindObjectOfType<GunScript>().GetSave(movesave);
                FindObjectOfType<PlayerTouch>().dUpdate(movesave);
                FindObjectOfType<ButtunManaImprovement>().GetSaveMana(movesave);
                FindObjectOfType<ManaAdd>().SetSave(movesave);
                HPText.text = " ";
                FindObjectOfType<Enemy>().DeathAnim();
                
                Osk.GetComponent<Animator>().Play("Jump");
                ButtuonNextScene.SetActive(true);
                ZoneTouch.SetActive(false);
                interAD.ShowAd();
                StartCoroutine(Destroy());
            }
            else
            {
                interAD.ShowAd();   
                FindObjectOfType<Enemy>().OnDestroy();
                FindObjectOfType<InfinityEnemy>().EnemyDie();
                FindObjectOfType<PlayerPrefsController>().InfinityInfo(HP);
                FindObjectOfType<PlayerPrefsController>().InfStartHP(9);
            }
           
        }
       
    }

    private void Level2()
    {
        if(Level > 1)
        {
            FindObjectOfType<LevelPrefs>().SetLeves(Level);
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
         movesave = true;
        FindObjectOfType<PlayerPrefsController>().InfinityInfo(HP);
        FindObjectOfType<GiveMyMoney>().UpdateSave(movesave);
        FindObjectOfType<ButtonDamgeImprovement>().SetSave(movesave);
        FindObjectOfType<ButtonDamageImrovementHero>().GetSaveHero(movesave);
        FindObjectOfType<GunScript>().GetSave(movesave);
        FindObjectOfType<PlayerTouch>().dUpdate(movesave);
        FindObjectOfType<ButtunManaImprovement>().GetSaveMana(movesave);
        FindObjectOfType<ManaAdd>().SetSave(movesave);
    }
#endif

    private void OnApplicationQuit()
    {
        movesave = true;
        FindObjectOfType<PlayerPrefsController>().InfinityInfo(HP);
        FindObjectOfType<GiveMyMoney>().UpdateSave(movesave);
        FindObjectOfType<ButtonDamgeImprovement>().SetSave(movesave);
        FindObjectOfType<ButtonDamageImrovementHero>().GetSaveHero(movesave);
        FindObjectOfType<GunScript>().GetSave(movesave);
        FindObjectOfType<PlayerTouch>().dUpdate(movesave);
        FindObjectOfType<ButtunManaImprovement>().GetSaveMana(movesave);
        FindObjectOfType<ManaAdd>().SetSave(movesave);
    }

    public void MenySave()
    {
        movesave = true;
        FindObjectOfType<PlayerPrefsController>().InfinityInfo(HP);
        FindObjectOfType<GiveMyMoney>().UpdateSave(movesave);
        FindObjectOfType<ButtonDamgeImprovement>().SetSave(movesave);
        FindObjectOfType<ButtonDamageImrovementHero>().GetSaveHero(movesave);
        FindObjectOfType<GunScript>().GetSave(movesave);
        FindObjectOfType<PlayerTouch>().dUpdate(movesave);
        FindObjectOfType<ButtunManaImprovement>().GetSaveMana(movesave);
        FindObjectOfType<ManaAdd>().SetSave(movesave);
    }


    public void InfinityLevel(float HPInf)
    {
        HP = HPInf;
        HPSlider.SetActive(true);
     
        HPText = GetComponentInChildren<Text>();
        HPText.text = HPInf.ToString();
        GetComponent<Slider>().value = HPInf;
        GetComponent<Slider>().maxValue = HPInf;
 
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<Enemy>().OnDestroy();
        HPSlider.SetActive(false);
    }
}
