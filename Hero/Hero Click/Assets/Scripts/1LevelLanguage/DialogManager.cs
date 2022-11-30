using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject Dialog, swordMan, Arrow, DamageHero, PlayeClick, AutoClick, Money, Portfel, ZoneTouch;
    public Text dialogueText;
    public Text nameText;
    float speed = 300f;
    [SerializeField] int Sentens;
    private Queue<string> sentences;

    private void Start()
    {
        swordMan.GetComponent<Animator>().Play("Jump");
        sentences = new Queue<string>();
        ZoneTouch.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void StartDialogue(Dialog dialogue)
    {
        
        Dialog.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    public void NextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            ZoneTouch.GetComponent<BoxCollider2D>().enabled = true;
            Portfel.GetComponent<Animator>().enabled = false;
            swordMan.GetComponent<Animator>().Play("Attack");
            DamageHero.GetComponent<Button>().enabled = true;
           PlayeClick.GetComponent<Button>().enabled = true;
            AutoClick.GetComponent<Button>().enabled = true;
            Money.GetComponent<Button>().enabled = true;
           
            return;
        }
        ButtonStory();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private void ButtonStory()
    {
        
        if(sentences.Count == 6)
        {
            Arrow.GetComponent<RectTransform>().anchoredPosition = new Vector2(-625, 595f);
            Arrow.SetActive(true);
            DamageHero.SetActive(true);
        }
        else if(sentences.Count == 5)
        {
            Arrow.GetComponent<RectTransform>().anchoredPosition = new Vector2(-181, 595f);
            Arrow.SetActive(true);
            PlayeClick.SetActive(true);
        }
        else if (sentences.Count == 4)
        {
            Arrow.GetComponent<RectTransform>().anchoredPosition = new Vector2(249, 595f);
            Arrow.SetActive(true);
            AutoClick.SetActive(true);
        }
        else if(sentences.Count == 3)
        {
            Arrow.GetComponent<RectTransform>().anchoredPosition = new Vector2(679, 595f);
            Arrow.SetActive(true);
            Money.SetActive(true);
        }
        else if (sentences.Count == 2)
        {
            Arrow.SetActive(false);
            Portfel.SetActive(true);
            Portfel.GetComponent<Animator>().Play("Drag");
        }
            
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Dialog.SetActive(false);
    }




    

}
