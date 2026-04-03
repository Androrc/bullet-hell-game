using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Variaveis
    private Rigidbody2D playerRigidbody2D;
    public float playerSpeed;
    private Vector2 playerDirection;
    public float delayDash;
    public bool isDash;
    public bool canDash;
    public float speeDash;
    public float timeDash;
    public bool isStun;
    public float speedStun;
    public float timeStun;
    public static Player Instance;
    public AudioSource audioSorce;
    public AudioClip dano;
    public Collider2D hitBox;

    private Animator playerAnimator;
    private string animacaoAtual;
    private Vector3 playerRotation;

    public GameObject painelGameOver;
    public Animator transitionAnimator;
    public GameObject mira;
    public GameObject painelDialogo, painelSaida;


    public int health = 5;
    public Image lifeImage;
    public Sprite[] lifeSprites;
    public bool estaVivo;
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOffFlashes;
    private SpriteRenderer spriteRend;
    public bool fezDialogoFazTudo;
    public bool fezDialogoBurn;
    private void Awake()
    {
        Instance= this;
        hitBox.enabled = true;
    }
    // Start
    void Start()
    {
        estaVivo = true;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update 
    void Update()
    {
        if(isDash == false && isStun == false)
        {
            playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        Dash();
        Animations();
    }

    void FixedUpdate()
    {
        if (Dialogue.instance.onDialogue == false)
        {
            if (isDash == false && isStun == false)
            {
                playerRigidbody2D.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
            }
            else
            {
                if (isDash == true)
                {
                    playerRigidbody2D.velocity = new Vector2(playerDirection.x * speeDash, playerDirection.y * speeDash);
                }
                
                if (isStun == true)
                {
                    playerRigidbody2D.velocity = new Vector2(playerDirection.x * speedStun, playerDirection.y * speedStun);
                }
                    

            }
        }
        else
        {
            playerRigidbody2D.velocity = Vector2.zero;
        }
    }

    public void Dash()
    {
        if(isDash == false && Input.GetAxis("Jump") != 0 && canDash == false)
        {
            StartCoroutine(TimeDash());

        }
    }

    private IEnumerator TimeDash()
    {
        canDash = true;
        isDash = true;
        yield return new WaitForSeconds(timeDash);
        isDash = false;
        yield return new WaitForSeconds(delayDash);
        canDash = false;
    }

    //Animções
    public void Animations()
    {
        if (estaVivo)
        {
            if (isStun == false)
            {
                if (isDash == true)
                {
                    ChangeAnimationState("Dash");
                }
                else
                {

                    if (playerRigidbody2D.velocity.x == 0 && playerRigidbody2D.velocity.y == 0)
                    {
                        ChangeAnimationState("Idle");
                    }

                    if (playerRigidbody2D.velocity.x != 0)
                    {
                        ChangeAnimationState("Walking");
                    }

                    if (playerRigidbody2D.velocity.y != 0)
                    {
                        ChangeAnimationState("Walking");
                    }
                }
            }
            else
            {
                ChangeAnimationState("Giro");
            }

            if (playerRigidbody2D.velocity.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            if (playerRigidbody2D.velocity.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

    }

    //Colisões
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "fuga")
        {
            painelSaida.SetActive(true);
        }
        if (collision.gameObject.tag == "Elev2")
        {
            StartCoroutine(Trasicao2());
        }
        if (collision.gameObject.tag == "salaElevador")
        {
            StartCoroutine(Trasicao());
        }
        if (collision.gameObject.tag == "Elev3")
        {
            StartCoroutine(Trasicao3());
        }
        if (collision.gameObject.tag == "Elev4")
        {
            StartCoroutine(Trasicao4());
        }
        if (collision.gameObject.tag == "saida")
        {
            StartCoroutine(Trasicao5());
        }
        if (collision.gameObject.tag == "Elev6")
        {
            StartCoroutine(Trasicao6());
        }
        if (collision.gameObject.tag == "corredorBurn")
        {
            StartCoroutine(Transicao7());
        }
        if(collision.gameObject.tag == "salaBurn")
        {
            StartCoroutine(Transicao8());
        }
        if(collision.gameObject.tag == "Elev7")
        {
            StartCoroutine(Transicao9());
        }
        if (collision.gameObject.tag == "Arma")
        {
            mira.SetActive(true);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "water")
        {
            StartCoroutine(TimeStun());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Bala")&& isDash == false)
        {
            Destroy(collision.gameObject);
            health--;
            audioSorce.PlayOneShot(dano);
 
            if (health <= 0)
            {
                estaVivo = false;
                StartCoroutine(GameOver());
                mira.SetActive(false);
                playerSpeed = 0;
            }
            else
            {
                StartCoroutine(Invulnerability());
            }
            lifeImage.sprite = lifeSprites[health];


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fuga")
        {
            painelSaida.SetActive(false);
        }
    }

    private IEnumerator Trasicao()
    {
        transitionAnimator.SetBool("Transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
    private IEnumerator Trasicao2()
    {
        transitionAnimator.SetBool("Transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }
    private IEnumerator Trasicao3()
    {
        transitionAnimator.SetBool("Transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);
    }
    private IEnumerator Trasicao4()
    {
        transitionAnimator.SetBool("Transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(5);
    }
    private IEnumerator Trasicao5()
    {
        transitionAnimator.SetBool("Transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(6);
    }
    private IEnumerator Trasicao6()
    {
        transitionAnimator.SetBool("Transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(7);
    }
    private IEnumerator Transicao9()
    {
        transitionAnimator.SetBool("Transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(8);
    }
    private IEnumerator Transicao7()
    {
        transitionAnimator.SetBool("Transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(9);
    }
    private IEnumerator Transicao8()
    {
        transitionAnimator.SetBool("Transition", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(10);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        for (int i = 0; i< numberOffFlashes; i++)
        {
            spriteRend.color = new Color(1, 1, 1, 0.3f);
            yield return new WaitForSeconds(iFramesDuration / (numberOffFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOffFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }

    private IEnumerator GameOver()
    {
        ChangeAnimationState("die");
        hitBox.enabled = false;
        yield return new WaitForSeconds(2);
        painelGameOver.SetActive(true);
    }
  
    
    
    void ChangeAnimationState(string newState)
    {
        if (animacaoAtual == newState)
            return;

        playerAnimator.Play(newState);
    }

    private IEnumerator TimeStun()
    {
        isStun = true;
        yield return new WaitForSeconds(timeStun);
        isStun = false;
       
    }
}
