using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TiroPoca : MonoBehaviour
{
    public float tempoPoca;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tempoPoca);
    }

    // Update is called once per frame
    void Update()
    {


    }

}