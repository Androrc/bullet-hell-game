using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public static Dialogue instance;
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;
    public LayerMask playerLayer;
    public float radious;
    private DialogueControl dc;
    bool onRadious;
    public bool onDialogue;
    public bool DialogueConcluidoFaztudo;
    public bool DialogueConcluidoBurn;
    public int idInimigo;

    private void Awake()
    {
        instance= this;
    }
    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {
        if (DialogueConcluidoFaztudo == false && onRadious && onDialogue == false)
        {
            onDialogue = true; 
            dc.Speech(profile, speechTxt, actorName);
        }
        if (DialogueConcluidoBurn == false && onRadious && onDialogue == false)
        {
            onDialogue = true;
            dc.Speech(profile, speechTxt, actorName);
        }
    }
    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if (hit != null)
        {
            switch (idInimigo)
            {
                case 0:
                    if (hit.gameObject.CompareTag("Player") && DialogueConcluidoFaztudo == false)
                    {
                        onRadious = true;
                    }
                    else
                    {
                        onRadious = false;
                    }
                    break;
                case 1:
                    if (hit.gameObject.CompareTag("Player") && DialogueConcluidoBurn == false)
                    {
                        onRadious = true;
                    }
                    else
                    {
                        onRadious = false;
                    }
                    break;
            }
        }



    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}