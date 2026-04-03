using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FazTudo : MonoBehaviour
{
    public int numero;
    public Rigidbody2D rb;
    public Animator playerAnimator;
    private string animacaoatual;
    private int randomSpot;
    public Transform[] moveSpot;
    public float startWaitTime;
    private float waitTime;
    public float speed;
    public bool dormindo;
    public float tempoParaDormir;
    public float tempoParaAcordar;
    public int health = 24;
    public Image lifeImage;
    public Sprite[] lifeSprites;
    bool FezDialogo;
    public GameObject vidaBoss;
    public Collider2D hitBox;
    public GameObject painelGameOver;
    //atirar
    public AudioSource audioSorce;
    public AudioClip tiro;
    public float timeBtwShots;
    public bool canShoot, reloading;
    public GameObject projectile, projectileFixed, miraShoot, miraAgua;
    public bool canPoca;
    public float timeBtwpoca;
    public bool pocante, iniciado;
    public bool estaVivo;
    // Start is called before the first frame update
    void Start()
    {
        estaVivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.fezDialogoFazTudo == true || estaVivo == false)
        {
            iniciarFazTudo();
            hitBox.enabled = true;
            //Movimentação
            if (dormindo == false)
            {

                Animations();
                transform.position = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].position, speed * Time.deltaTime);

                if (estaVivo)
                {
                    if (transform.position.x > Player.Instance.transform.position.x)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                }
                if (Vector2.Distance(transform.position, moveSpot[randomSpot].position) < 0.2f)
                {
                    if (waitTime <= 0)
                    {
                        randomSpot = Random.Range(0, moveSpot.Length);
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
                //Tiro
                if (canShoot == true)
                {
                    escolherAtaque();
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
                StartCoroutine(GameOver());
            }


        }
    }

    public void iniciarFazTudo()
    {
        if (iniciado == false)
        {
            iniciado = true;
            randomSpot = Random.Range(0, moveSpot.Length);
            escolherAtaque();
            StartCoroutine(BotarPraDormir());
            vidaBoss.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tiro"))
        {
            health = health - 1;
            if (health <= 0)
            {
                estaVivo = false;
                StartCoroutine(GameOver());
                speed = 0;
            }
        }
        if (health % 2 == 0)
        {
            lifeImage.sprite = lifeSprites[health / 2];

        }
    }

    void escolherAtaque()
    {
        int rnd = Random.Range(0, 2);
        switch (rnd)
        {
            case 0:
                StartCoroutine(reload());
                break;
            case 1:
                StartCoroutine(especial());
                break;
        }
    }
    IEnumerator reload()
    {
        ChangeAnimationState("Attack");

        canShoot = false;
        reloading = false;
        audioSorce.PlayOneShot(tiro);
        yield return new WaitForSeconds(0.1F);
        Instantiate(projectile, miraShoot.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2F);
        reloading = true;
        yield return new WaitForSeconds(timeBtwShots * 3);
        canShoot = true;
    }

    IEnumerator especial()
    {
        ChangeAnimationState("SplashAttack");

        canShoot = false;
        pocante = false;
        yield return new WaitForSeconds(0.2F);
        Instantiate(projectileFixed, miraAgua.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2F);
        pocante = true;
        yield return new WaitForSeconds(timeBtwShots * 3);
        canShoot = true;
    }
    public void Animations()
    {
        if (estaVivo)
        {
            if (pocante == true && reloading == true)
            {

                if (dormindo == true)
                {
                    ChangeAnimationState("Off");
                }
                else
                {
                    if (rb.velocity.x == 0 && rb.velocity.y == 0)
                    {
                        ChangeAnimationState("Idle");
                    }

                    if (rb.velocity.x != 0)
                    {
                        ChangeAnimationState("Walking");
                    }
                }
            }
        }
    }

    IEnumerator BotarPraDormir()
    {
        yield return new WaitForSeconds(tempoParaDormir);
        pocante = true;
        reloading = true;
        dormindo = true;
        Animations();
        StartCoroutine(Acordar());
    }

    IEnumerator Acordar()
    {
        yield return new WaitForSeconds(tempoParaAcordar);
        StartCoroutine(BotarPraDormir());
        dormindo = false;
    }

    void ChangeAnimationState(string newState)
    {
        if (animacaoatual == newState)
            return;

        playerAnimator.Play(newState);
    }

    IEnumerator GameOver()
    {
        ChangeAnimationState("Morte");
 
        dormindo = false;
        StopAllCoroutines();
        switch (numero)
        {
            case 0:
                saida.instance.vidaZelador1 = true;
                break;
            case 1:
                saida.instance.vidaZelador2 = true;
                break;
            case 2:
                saida.instance.vidaZelador3 = true;
                break;
        }
        yield return new WaitForSeconds(0);
    }
}
