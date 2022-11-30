using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PlayerPrefsController : MonoBehaviour
{
    private Save sv = new Save();
    private SaveDam svd = new SaveDam();
    private SaveHP svhp = new SaveHP();
    public int Scene;

    private void Start()
    {
        if (Scene == 0)
        {
            return;
        }
        else
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));
            svd = JsonUtility.FromJson<SaveDam>(PlayerPrefs.GetString("Savek"));
            FindObjectOfType<ButtonDamgeImprovement>().Getsave(svd.cashdam, svd.cashxDam, svd.Level, svd.Levelx, svd.ChechDAm);
            FindObjectOfType<ButtonDamageImrovementHero>().Getsave(sv.cashdamH, sv.cashxDamH, sv.LevelH, sv.LevelxH, sv.ChechDAmH);
            FindObjectOfType<PlayerTouch>().GetSave(sv.TapDamage, sv.Tap500, sv.Tap1000);
            FindObjectOfType<GunScript>().SetSave(sv.HeroDam, sv.HeroMOny);
            FindObjectOfType<ButtunManaImprovement>().Getsave(sv.cashdamM, sv.cashxDamM, sv.LevelM, sv.LevelxM, sv.ChechDAmM);
            FindObjectOfType<ManaAdd>().GetSave(sv.Mana);
            FindObjectOfType<GiveMyMoney>().AddMoney(sv.Money);

        }
    }





    public void SaveNextMoney(float Money)
    {
        if (!PlayerPrefs.HasKey("Save"))
        {
            sv.Money = Money;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
        else
        {
            sv.Money = Money;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
    }

    public void SaveNextDamageLevel(int cashDam, int cashxDam, int Level, int Levelx, int CheckNumber)
    {
        if (!PlayerPrefs.HasKey("Savek"))
        {
            svd.cashdam = cashDam;
            svd.cashxDam = cashxDam;
            svd.Level = Level;
            svd.Levelx = Levelx;
            svd.ChechDAm = CheckNumber;
            PlayerPrefs.SetString("Savek", JsonUtility.ToJson(svd));
        }
        else
        {
            svd.cashdam = cashDam;
            svd.cashxDam = cashxDam;
            svd.Level = Level;
            svd.Levelx = Levelx;
            svd.ChechDAm = CheckNumber;
            PlayerPrefs.SetString("Savek", JsonUtility.ToJson(svd));
        }

    }

    public void SaveTapDamage(float Tapdamage)
    {
        if (!PlayerPrefs.HasKey("Save"))
        {
            sv.TapDamage = Tapdamage;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
        else
        {
            sv.TapDamage = Tapdamage;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
    }

    public void SaveMonyTap(int Tap500, int Tap1000)
    {
        if (!PlayerPrefs.HasKey("Save"))
        {
            sv.Tap500 = Tap500;
            sv.Tap1000 = Tap1000;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
        else
        {
            sv.Tap500 = Tap500;
            sv.Tap1000 = Tap1000;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
    }

    public void SaveNextHeroLevel(int cashDamHero, int cashxDamHero, int LevelHero, int LevelxHero, int CheckNumberHero)
    {
        if (!PlayerPrefs.HasKey("Save"))
        {
            sv.cashdamH = cashDamHero;
            sv.cashxDamH = cashxDamHero;
            sv.LevelH = LevelHero;
            sv.LevelxH = LevelxHero;
            sv.ChechDAmH = CheckNumberHero;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
        else
        {
            sv.cashdamH = cashDamHero;
            sv.cashxDamH = cashxDamHero;
            sv.LevelH = LevelHero;
            sv.LevelxH = LevelxHero;
            sv.ChechDAmH = CheckNumberHero;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
    }

    public void SaveHeroDamageMoney(float HeroDam, int HeroMany)
    {
        if (!PlayerPrefs.HasKey("Save"))
        {
            sv.HeroDam = HeroDam;
            sv.HeroMOny = HeroMany;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
        else
        {
            sv.HeroDam = HeroDam;
            sv.HeroMOny = HeroMany;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
    }

    public void SaveNextManaLevel(int cashMana, int cashxMana, int LevelMana, int LevelxMana, int CheckNumberMana)
    {
        if (!PlayerPrefs.HasKey("Save"))
        {
            sv.cashdamM = cashMana;
            sv.cashxDamM = cashxMana;
            sv.LevelM = LevelMana;
            sv.LevelxM = LevelxMana;
            sv.ChechDAmM = CheckNumberMana;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
        else
        {
            sv.cashdamM = cashMana;
            sv.cashxDamM = cashxMana;
            sv.LevelM = LevelMana;
            sv.LevelxM = LevelxMana;
            sv.ChechDAmM = CheckNumberMana;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }


    }

    public void ManaInfo(float Mana)
    {
        if (!PlayerPrefs.HasKey("Save"))
        {
            sv.Mana = Mana;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }

        else
        {
            sv.Mana = Mana;
            PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        }
    }

    public void InfinityInfo(float HPs)
    {
        if (!PlayerPrefs.HasKey("SaveInf"))
        {
            svhp.HP = HPs;
            PlayerPrefs.SetString("SaveInf", JsonUtility.ToJson(svhp));
        }

        else
        {
            svhp.HP = HPs;
            PlayerPrefs.SetString("SaveInf", JsonUtility.ToJson(svhp));
        }
    }

    public void InfStartHP(int Level)
    {
        if(Level == 9)
        {
            svhp = JsonUtility.FromJson<SaveHP>(PlayerPrefs.GetString("SaveInf"));
            FindObjectOfType<InfinityEnemy>().SaveI(svhp.I, svhp.sHP);
            FindObjectOfType<InfinityEnemy>().SaveHp(svhp.HP);

        }
    }

    public void SaveIE(int ie, float sHP)
    {

        if (!PlayerPrefs.HasKey("SaveInf"))
        {
            svhp.I = ie;

            svhp.sHP = sHP;
            PlayerPrefs.SetString("SaveInf", JsonUtility.ToJson(svhp));
        }

        else
        {
            svhp.I = ie;
            svhp.sHP = sHP;
            PlayerPrefs.SetString("SaveInf", JsonUtility.ToJson(svhp));
        }
    }


#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        PlayerPrefs.SetString("Savek", JsonUtility.ToJson(svd));
          PlayerPrefs.SetString("SaveInf", JsonUtility.ToJson(svhp));

    }
#endif

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        PlayerPrefs.SetString("Savek", JsonUtility.ToJson(svd));
        PlayerPrefs.SetString("SaveInf", JsonUtility.ToJson(svhp));
    }
    [Serializable]
    public class Save
    {
        public float Money;

        public float TapDamage;
        public int Tap500;
        public int Tap1000;
        public int cashdamH;
        public int cashxDamH;
        public int LevelH;
        public int LevelxH;
        public int ChechDAmH;
        public float HeroDam;
        public int HeroMOny;
        public int cashdamM;
        public int cashxDamM;
        public int LevelM;
        public int LevelxM;
        public int ChechDAmM;
        public float Mana;
    }
    [Serializable]
    public class SaveDam
    {
        public int cashdam;
        public int cashxDam;
        public int Level;
        public int Levelx;
        public int ChechDAm;
    }

    [Serializable]
    
    public class SaveHP
    {
        public float HP;
        public float sHP;
        public int I;

    }
}
        

