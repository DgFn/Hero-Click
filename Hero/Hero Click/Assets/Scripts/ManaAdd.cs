using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaAdd : MonoBehaviour
{
    public GameObject Slider;
    Text ManaText;
   [SerializeField] float Manaplus;
    float MaxMana = 200;
   [SerializeField] float Mana;
    public Text InfoMana;
    float basicMana = 20;
    bool move = false;
    int language = 0;
    // Start is called before the first frame update
    void Start()
    {
        ManaText = GetComponentInChildren<Text>();
        StartCoroutine(AddMana());   
    }

    public void GetSave(float Mana)
    {
        basicMana = Mana;
    }
    private void Update()
    {
        if(language == 0)
        {
            InfoMana.text = "Received Mana: " + basicMana.ToString();
        }
        else
        {
            InfoMana.text = "Получаемая мана: " + basicMana.ToString();
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

    public void SetSave(bool save)
    {
        move = save;
        if(move)
        {
            FindObjectOfType<PlayerPrefsController>().ManaInfo(basicMana);
            move = false;
        }
    }

    public void TakeMana(float Manax)
    {
         
        basicMana += Manax;
    }

    public void DragonMana(int ManaD)
    {
        Mana += ManaD;
        if (Mana > MaxMana)
        {
            Mana = MaxMana;
        }
        UpdateDisplay();
    }


    // Update is called once per frame
     public void UpdateDisplay()
    {
        Slider.GetComponent<Slider>().value = Mana;
        ManaText.text = Mana.ToString();
        FindObjectOfType<buttonmassive>().ManaCheck(Mana);
    }

    IEnumerator AddMana()
    {
            yield return new WaitForSeconds(120);
        
            Mana += basicMana;
        if(Mana > MaxMana)
        {
            Mana = MaxMana;
        }
            UpdateDisplay();
        StartCoroutine(AddMana());
    }

    public void MinusMana(int ManaMinus)
    {
        if(Mana >= 40)
        {
            Mana -= ManaMinus;
            UpdateDisplay();
        }
        
    }

}
