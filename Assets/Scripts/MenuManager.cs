using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject painelMenu, painelOptions;
    public AudioSource jukebox;
    public AudioClip music, efeito;

    private void Awake()
    {
        painelMenu.SetActive(true);
        painelOptions.SetActive(false);
    }

    void Start()
    {
       // jukebox.Play();
    }

    public void MudarOpcoes()
    {
        jukebox.PlayOneShot(efeito);
        painelMenu.SetActive(false);
        painelOptions.SetActive(true);
    }

    public void MudarMenu()
    {
        jukebox.PlayOneShot(efeito);
        painelMenu.SetActive(true);
        painelOptions.SetActive(false);
    }


    public void IrParaJogo()
    {
        SceneManager.LoadScene(1);
    }

    public void ReIniciar1()
    {
        SceneManager.LoadScene(4);
    }

    public void ReIniciar2()
    {
        SceneManager.LoadScene(8);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

}

