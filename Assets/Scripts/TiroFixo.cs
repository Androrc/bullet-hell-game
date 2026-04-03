using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroFixo : MonoBehaviour
{
    private Rigidbody2D rbFixo;
 





    // Start is called before the first frame update
    void Start()
    {
        rbFixo = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
     

        if (other.CompareTag("Parede"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
