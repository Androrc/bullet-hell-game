using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saida : MonoBehaviour
{
    public static saida instance;
    public bool vidaZelador1;
    public bool vidaZelador2;
    public bool vidaZelador3;
    public Collider2D hitBox, saida2;
    public GameObject vidaBoss;
    public AudioSource musicaBoss;
    public GameObject gameOver;
    private void Awake()
    {
        musicaBoss.enabled = true;  
        gameOver.SetActive(false);
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaZelador1 && vidaZelador2 && vidaZelador3)
        {
            hitBox.enabled = true;
            saida2.enabled = true;
            vidaBoss.SetActive(false);

        }

        if(gameOver.activeInHierarchy == true)
        {
            musicaBoss.enabled = false;
        }
    }
}
