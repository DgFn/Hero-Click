using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

 public class SaveLanguage : MonoBehaviour 
{

    private SaveLang svl = new SaveLang();
    public Text PlayRu, PlayEngl, OptionsRu, OptionsEngl, QuitRu, QuitEngl, BackRU, BackEngl, LangRu, LangEngl;
    public GameObject RU, Engl, NextRu, NExtEngl;
    public Text NextLevelRu, NextLevelEngl, MenuRu, MenuEngl;
    public Text R1, E1, R2, E2, R3, E3, R4, E4, R5, E5, R6, E6, R7, E7, R8, E8, RM, EM;
    public int Levels;
    [SerializeField] float MenuC = 0;


    private void Start()

    {
        MenuCheck();
        OptionsCheck();
        if(Levels == 9)

        {
            LevelInfinity();
        }
        else
        {
            LevelCheck();
        }
        Levelmenu();
    }

    public void MenuCheck()
    {
        if(MenuC == 1)
        {
            Menu();
        }
     

    }

    public void OptionsCheck()
    {
       if (MenuC == 2)
        {
            Options();
        }
    }

    public void LevelCheck()
    {
        if(MenuC == 3)
        {
            Level();
        }
    }

    public void Levelmenu()
    {
        if(MenuC == 4)
        {
            MenuLevel();
        }
    }

    public void MenuLevel()
    {
        svl = JsonUtility.FromJson<SaveLang>(PlayerPrefs.GetString("SaveLang"));
        if (svl.Lang == 0)
        {
            E1.enabled = true;
            E2.enabled = true;
            E3.enabled = true;
            E4.enabled = true;
            E5.enabled = true;
            E6.enabled = true;
            E7.enabled = true;
            E8.enabled = true;
            EM.enabled = true;

            R1.enabled = false;
            R2.enabled = false;
            R3.enabled = false;
            R4.enabled = false;
            R5.enabled = false;
            R6.enabled = false;
            R7.enabled = false;
            R8.enabled = false;
            RM.enabled = false;
        }
        else
        {
            E1.enabled = false;
            E2.enabled = false;
            E3.enabled = false;
            E4.enabled = false;
            E5.enabled = false;
            E6.enabled = false;
            E7.enabled = false;
            E8.enabled = false;
            EM.enabled = false;

            R1.enabled = true;
            R2.enabled = true;
            R3.enabled = true;
            R4.enabled = true;
            R5.enabled = true;
            R6.enabled = true;
            R7.enabled = true;
            R8.enabled = true;
            RM.enabled = true;
        }
    }

    public void Level()
    {
        svl = JsonUtility.FromJson<SaveLang>(PlayerPrefs.GetString("SaveLang"));
        if (svl.Lang == 0)
        {
            RU.SetActive(false);
            Engl.SetActive(true);
            NextRu.SetActive(false);
            NExtEngl.SetActive(true);
            NextLevelRu.enabled = false;
            NextLevelEngl.enabled = true;
            MenuRu.enabled = false;
            MenuEngl.enabled = true;
            FindObjectOfType<PlayerTouch>().UpdateLang(svl.Lang);
            FindObjectOfType<GunScript>().UpdateLang(svl.Lang);
            FindObjectOfType<ManaAdd>().UpdateLang(svl.Lang);
        }
        else
        {
            RU.SetActive(true);
            Engl.SetActive(false);
            NextRu.SetActive(true);
            NExtEngl.SetActive(false);
            NextLevelRu.enabled = true;
            NextLevelEngl.enabled = false;
            MenuRu.enabled = true;
            MenuEngl.enabled = false;
            FindObjectOfType<PlayerTouch>().UpdateLang(svl.Lang);
            FindObjectOfType<GunScript>().UpdateLang(svl.Lang);
            FindObjectOfType<ManaAdd>().UpdateLang(svl.Lang);
        }
    }

    public void LevelInfinity()
    {
        svl = JsonUtility.FromJson<SaveLang>(PlayerPrefs.GetString("SaveLang"));
        if (svl.Lang == 0)
        {
            MenuRu.enabled = false;
            MenuEngl.enabled = true;
            FindObjectOfType<PlayerTouch>().UpdateLang(svl.Lang);
            FindObjectOfType<GunScript>().UpdateLang(svl.Lang);
            FindObjectOfType<ManaAdd>().UpdateLang(svl.Lang);
        }
        else
        {
            MenuRu.enabled = true;
            MenuEngl.enabled = false;
            FindObjectOfType<PlayerTouch>().UpdateLang(svl.Lang);
            FindObjectOfType<GunScript>().UpdateLang(svl.Lang);
            FindObjectOfType<ManaAdd>().UpdateLang(svl.Lang);
        }
    }




    public void ChooseLanguage(int Number)
    {
        if (Number == 0)
        {
            svl.Lang = 0;
            PlayerPrefs.SetString("SaveLang", JsonUtility.ToJson(svl));
        }
        else if(Number == 1)
        {
            svl.Lang = 1;
            PlayerPrefs.SetString("SaveLang", JsonUtility.ToJson(svl));    
        }
        OptionsCheck();
    } 

    public void Options()
    {
        svl = JsonUtility.FromJson<SaveLang>(PlayerPrefs.GetString("SaveLang"));
        if (svl.Lang == 0)
        {
            BackRU.enabled = false;
            BackEngl.enabled = true;
            LangRu.enabled = false;
            LangEngl.enabled = true;
        }
        else
        {
            BackRU.enabled = true;
            BackEngl.enabled = false;
            LangRu.enabled = true;
            LangEngl.enabled = false;
        }
    }

    public void Menu()
    {
        svl = JsonUtility.FromJson<SaveLang>(PlayerPrefs.GetString("SaveLang"));
        if (svl.Lang == 0)
        {
            PlayRu.enabled = false;
            OptionsRu.enabled = false;
            QuitRu.enabled = false;
            PlayEngl.enabled = true;
            OptionsEngl.enabled = true;
            QuitEngl.enabled = true;
        }
        else
        {
            PlayRu.enabled = true;
            OptionsRu.enabled = true;
            QuitRu.enabled = true;
            PlayEngl.enabled = false;
            OptionsEngl.enabled = false;
            QuitEngl.enabled = false;
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        PlayerPrefs.SetString("SaveLang", JsonUtility.ToJson(svl));
    }
#endif

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("SaveLang", JsonUtility.ToJson(svl));
    }






    [Serializable]
    public class SaveLang
    {
        public int Lang;
    }
}
