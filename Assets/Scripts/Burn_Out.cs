using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Burn_Out : MonoBehaviour
{
    public static Burn_Out instance;
    
    // ===== Movement =====
    public float speed;
    public Transform[] moveSpot;
    private Rigidbody2D burnrb;
    private int randomSpot;
    public float startWaitTime;
    private float waitTime;

    // ===== Audio =====
    public AudioSource audioSorce;
    public AudioClip tiro, musicaBurn;

    // ===== Health =====
    public int health = 50;
    public Image lifeImage;
    public Sprite[] lifeSprites;

    // ===== Shooting =====
    public float timeBtwShots;
    public bool canShoot, reloading;
    public GameObject projectile, projectileFixed, vidaBoss;
    public bool estaVivo;
    public Collider2D hitBox;

    // ===== Animation =====
    private Animator burnanimator;
    public bool iniciado;
    private string animacaoAtual;

    private void Awake()
    {
        instance = this;
        estaVivo = true;
    }
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpot.Length);
        burnrb = GetComponent<Rigidbody2D>();
        canShoot = true;
        burnanimator = GetComponent<Animator>();
    }





    void Update()
    {
        if (Player.Instance.fezDialogoBurn == true)
        {
            iniciarBurn();
            hitBox.enabled = true;
            Animations();


            // ===== Movement logic =====

            transform.position = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].position, speed * Time.deltaTime);
            if (estaVivo)
            {
                if (transform.position.x > Player.Instance.transform.position.x)
                {
                    transform.localScale = new Vector3(2, 2, 2);
                }
                else
                {
                    transform.localScale = new Vector3(-2, 2, 2);
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


            // ===== Shooting =====
            if (canShoot == true)
            {
                StartCoroutine(reload());
            }
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PontoE"))
            {
            StartCoroutine(especial());
            }
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
            if(health%5 == 0)
            {
            lifeImage.sprite = lifeSprites[(health/5) - 1];
            }
        }

    // ===== Regular shooting coroutine =====   
    IEnumerator reload()
    {
        ChangeAnimationState("portilha");
        Instantiate(projectile, transform.position, Quaternion.identity);
        canShoot = false;
        reloading = false;
        yield return new WaitForSeconds(timeBtwShots);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwShots - 0.1f);
        audioSorce.PlayOneShot(tiro);
        Instantiate(projectile, transform.position, Quaternion.identity);

        reloading = true;
        yield return new WaitForSeconds(timeBtwShots * 3);
        canShoot = true;
    }

    // ===== Special attack =====
    IEnumerator especial()
    {
        canShoot = false;
        GameObject go = null;
        for (int i = 0; i < 20; i++)
        {
            go = Instantiate(projectileFixed, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));

        }
        yield return new WaitForSeconds(5);

    }

    // ===== Start boss fight =====
    public void iniciarBurn()
    {
        if (iniciado == false)
        {
            iniciado = true;
            randomSpot = Random.Range(0, moveSpot.Length);
            vidaBoss.SetActive(true);
        }
    }

    // ===== Animation handling =====
    public void Animations()
    {

        if (reloading == true)
        {
            ChangeAnimationState("Idle_BurnOut");
        }

    }

    void ChangeAnimationState(string newState)
    {
        if (animacaoAtual == newState)
            return;

        burnanimator.Play(newState);
    }

    // ===== Boss defeat =====
    IEnumerator GameOver()
    {
        ChangeAnimationState("Die");
        StopAllCoroutines();
        yield return new WaitForSeconds(0);
    }

}