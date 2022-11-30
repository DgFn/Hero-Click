using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityEnemy : MonoBehaviour
{
    public List<GameObject> Enemy;
    public GameObject ParentEnemy;
   public float HP = 300000;
   public int i = 0;

    public void SaveI(int iz, float sHP)
    {
        i = iz;
        HP = sHP;
    }

    public void SaveHp(float HPSave)
    {
        if(HPSave == 0)
        {
            Debug.Log("ya cuka");
            Instantiate(Enemy[i], ParentEnemy.transform);
            FindObjectOfType<HPSLider>().InfinityLevel(HP);
            HP += 100000;
            i++;
            I();
        }
        else 
        {
            if (HP >= HPSave)
            {
                Debug.Log("ya cuka2");
                Instantiate(Enemy[i], ParentEnemy.transform);
                FindObjectOfType<HPSLider>().InfinityLevel(HPSave);
                HP += 100000;
                i++;
                I();
            }
            
        }
    }

    public void EnemyDie()
    {
        FindObjectOfType<PlayerPrefsController>().SaveIE(i, HP);
    }

    public void I()
    {
        if(i == 4)
        {
            i = 0;
        }
    }

  
}
