using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro_FazTudo : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Transform player;
    private Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = target - transform.position;
        Vector3 rotation = transform.position - target;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot * 90);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }

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
