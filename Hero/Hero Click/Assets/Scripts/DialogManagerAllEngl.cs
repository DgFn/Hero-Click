using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManagerAllEngl : MonoBehaviour
{
    public GameObject Dialog, swordMan, PlayerClick, ButtonHero, AutoClick, Money, Enemy, OrcButton, ZoneTouch, Dragon;
    public Text dialogueText;
    public Text nameText;
    private Queue<string> sentences;

    private void Start()
    {
        Dragon.GetComponent<Button>().enabled = false;
        ZoneTouch.GetComponent<BoxCollider2D>().enabled = false;
        Enemy.GetComponent<Animator>().enabled = false;
        swordMan.GetComponent<Animator>().Play("Jump");
        sentences = new Queue<string>();
        PlayerClick.GetComponent<Button>().enabled = false;
        ButtonHero.GetComponent<Button>().enabled = false;
        AutoClick.GetComponent<Button>().enabled = false;
        Money.GetComponent<Button>().enabled = false;
        OrcButton.GetComponent<Button>().enabled = false;
    }

    public void StartDialogue(DialoAllEngl dialogue)
    {

        Dialog.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            Dragon.GetComponent<Button>().enabled = true;
            ZoneTouch.GetComponent<BoxCollider2D>().enabled = true;
            PlayerClick.GetComponent<Button>().enabled = true;
            ButtonHero.GetComponent<Button>().enabled = true;
            AutoClick.GetComponent<Button>().enabled = true;
            Money.GetComponent<Button>().enabled = true;
            OrcButton.GetComponent<Button>().enabled = true;
            EndDialogue();
            swordMan.GetComponent<Animator>().Play("Attack");
           Enemy.GetComponent<Animator>().enabled = true;
            return;
        }
        ButtonStory();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private void ButtonStory()
    {

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
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

