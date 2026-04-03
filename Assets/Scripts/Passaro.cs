using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passaro : MonoBehaviour
{
    public GameObject posicaoPassaro;
    private Rigidbody2D passaroRigidbody;
    public float passarospeed;
    private Vector2 passaroDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, posicaoPassaro.transform.position, passarospeed);
    }

    public void Lado()
    {

    }
}

