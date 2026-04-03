using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public TMP_Text speechText;
    public TMP_Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;
    public int idInimigo;

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }
    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index]) 
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //lido quando acabar os textos 
            {
                speechText.text = ""; 
                index = 0;
                dialogueObj.SetActive(false);
                Dialogue.instance.onDialogue = false;
                switch(Dialogue.instance.idInimigo)
                {
                    case 0:
                        Player.Instance.fezDialogoFazTudo = true;
                        break;
                    case 1:
                        Player.Instance.fezDialogoBurn= true;
                        break;
                }

            }
        }
        else
        {
            StopAllCoroutines();
            speechText.text = sentences[index];
            if(idInimigo == 0)
            {
                Dialogue.instance.DialogueConcluidoFaztudo = true;
            }
            if (idInimigo == 1)
            {
                Dialogue.instance.DialogueConcluidoBurn = true;
            }
        }
    }
}
