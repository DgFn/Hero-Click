using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelPrefs : MonoBehaviour
{
   public List<GameObject> Levels;
    public GameObject InfinityButton;
    private SaveLevel svlev = new SaveLevel();
    public int Level = 0;
    int Lev;
    int Levis;





    private void Start()
    {
        if(Level == 1)
        {
            svlev = JsonUtility.FromJson<SaveLevel>(PlayerPrefs.GetString("SaveLevel"));
            if (svlev.NumberLevels == 9)
            {
                StartInfLev();
                LevelFinish();
            }
            else
            {
                LevelActive();
                LevelFinish();
            }
        }
       
    }

    private void StartInfLev()
    {
        if (Level == 1)
        {
            InfinityGame();
        }
    }

    public void SetLeves(int Levels)
    {
        svlev = JsonUtility.FromJson<SaveLevel>(PlayerPrefs.GetString("SaveLevel"));
        Levis = Levels;
        svlev.NumberLevels = Levis;
        PlayerPrefs.SetString("SaveLevel", JsonUtility.ToJson(svlev));
    }



    private void LevelActive()
    { 
        if(Level == 1)
        {

            svlev = JsonUtility.FromJson<SaveLevel>(PlayerPrefs.GetString("SaveLevel"));
            Lev = svlev.NumberLevels;

            for (int i = 0; i < Lev; i++)
            {
                Levels[i].SetActive(true);
            }
        } 
    }
    public void LevelFinish()
    {
        if(Level == 1)
        {
            svlev = JsonUtility.FromJson<SaveLevel>(PlayerPrefs.GetString("SaveLevel"));
            Lev = svlev.NumberLevels;
            for (int m = 0; m < Lev - 1; m++)
            {
                Levels[m].GetComponent<Button>().enabled = false;
            }
        }
    }

    public void InfinityGame()
    {
        svlev = JsonUtility.FromJson<SaveLevel>(PlayerPrefs.GetString("SaveLevel"));
        if (svlev.NumberLevels == 9)
        {
            Lev = svlev.NumberLevels;
            for (int i = 0; i < Lev; i++)
            {
                Levels[i].SetActive(false);
                InfinityButton.SetActive(true);
            }
        } 
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        PlayerPrefs.SetString("SaveLevel", JsonUtility.ToJson(svlev));
    }
#endif

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("SaveLevel", JsonUtility.ToJson(svlev));
    }

    [Serializable]
    public class SaveLevel
    {
        public int NumberLevels;
    }
}
