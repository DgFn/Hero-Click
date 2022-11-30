using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CaseScript : MonoBehaviour
{
    public List<GameObject> BlueSkinsList;
    public List<GameObject> PurpleSkinsList;
    public List<GameObject> RedSkinsList;
    public List<GameObject> LegendarySkinsList;
    public Transform Skin;
    float RandomNumb;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = this.transform.GetComponent<Animator>();
    }

    public void OnMouseDown()
    {
        m_Animator.Play("BearOpen");
        StartCoroutine(StartDrop());  
    }

    IEnumerator StartDrop()
    {
        yield return new WaitForSeconds(1);
        Skins();
    }

    public void Skins()
    {
        RandomNumb = Random.Range(1, 1000);
        
        if( RandomNumb < 850)
        {
            BlueSkinsList[Random.Range(1, 10)].transform.position = Skin.transform.position;
            StartCoroutine(DestroyCase());
        }
        else
        {
            CheckRate(RandomNumb);
        }
      
        Debug.Log(RandomNumb);
    }

    public void CheckRate(float RandomNumb)
    {
        if (RandomNumb > 850 && RandomNumb < 950)
        {
            PurpleSkinsList[Random.Range(1, 5)].transform.position = Skin.transform.position;
            StartCoroutine(DestroyCase());
        }
        else
        {
            RedRate(RandomNumb);
        }

       

    }

    public void RedRate(float RandomR)
    {
        if (RandomR > 950 && RandomR < 990)
        {
             RedSkinsList[Random.Range(1, 2)].transform.position = Skin.transform.position;
            StartCoroutine(DestroyCase());
        }
        else
        {
            LegendaryRate(RandomR);
        }

    }

    public void LegendaryRate(float LegendaryNum)
    {
          if (LegendaryNum > 990 && LegendaryNum < 1001)
        {

             LegendarySkinsList[1].transform.position = Skin.transform.position;
            StartCoroutine(DestroyCase());

        }
    }

    IEnumerator DestroyCase()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }


    // Update is called once per frame

}
