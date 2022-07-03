using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoviment : MonoBehaviour
{

     
    public GameObject player; // esquerda bala
    private Transform playTransm;

    public AudioSource boomSound;  // efeito de explosão


    private Rigidbody2D bulletRB;

    public float bulletSpeed;
    public float bulletLife;

    public static int damage;   // quantas balas atirou
    public int damageRef;// referencia ,vai colocar o valor ,o valor de pontos 


    private void Awake()
    {

        damage = damageRef;

        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        playTransm = player.transform;
    }
    void Start()
    {
        if (playTransm.localScale.x > 0)
        {
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject , bulletLife);
        
    }


     void OnTriggerEnter2D(Collider2D col)
    {
     
        if(col.tag == "Plataform"  || col.tag  == "Enemy" || col.tag == "Missile")
        {
            GetComponent<ParticleSystem>().Play();
            boomSound.Play();

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

           

        }

    }
    


}
