using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    public AudioClip altýn, dusme;
    public OyunKontrol oyunk;
    private float hiz = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunk.oyunAktif) { 
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical"); ;

        x *= Time.deltaTime  * hiz;
        y *= Time.deltaTime  * hiz;

        transform.Translate(x, 0f, y);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals("Altýn"))
        {
            GetComponent<AudioSource>().PlayOneShot(altýn,0.7f);
            oyunk.AltinArttir();
            Destroy(c.gameObject);
        } 
        else if (c.gameObject.tag.Equals("Dusman"))
        {
            GetComponent<AudioSource>().PlayOneShot(dusme, 0.7f);
            oyunk.oyunAktif = false;
        }
    }
}
