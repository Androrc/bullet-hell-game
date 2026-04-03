using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public AudioSource audioSorce;
    public AudioClip tiro;

    // Start is called before the first frame update
    void Start()
    {
       canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rbtZ = Mathf.Atan2(-rotation.y, -rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rbtZ);


        if (Input.GetMouseButton(0) && canFire && Dialogue.instance.onDialogue == false)
        {
            StartCoroutine(recarregar());
        }



    }
    IEnumerator recarregar()
    {
        canFire = false;
        Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        audioSorce.PlayOneShot(tiro);
        yield return new WaitForSeconds(timeBetweenFiring);
        canFire = true;
    }

}
