using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    private Transform playerTrans;

    public GameObject explosion;  // a explosão 

     AudioSource boomSound;  // som quando bate em algo

    Rigidbody2D missileRB;

    public float missileSpeed;

    public float missileLife; // prazo e vida do missel


     void Awake()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        missileRB = GetComponent<Rigidbody2D>();

        boomSound = GameObject.Find("MissileBoom").GetComponent<AudioSource>();

    }

    void Start()
    {

        if(playerTrans.position.x  <  transform.localPosition.x)  // "jogador"  menor  "posiçao do missel"
        {
            missileRB.velocity = new Vector2(-missileSpeed, missileRB.velocity.y);
            GetComponent<SpriteRenderer>().flipY = false;
            
        }
        else
        {
            missileRB.velocity = new Vector2(missileSpeed, missileRB.velocity.y); // pos
            GetComponent<SpriteRenderer>().flipY = true ;

        }
        
    }

    // Update is called once per frame
    void Update()
    {

        Destroy(gameObject, missileLife);
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"  || other.tag == "Bullet")
        {

            Instantiate(explosion, transform.position, transform.rotation);
            boomSound.Play(); // liga
            Destroy(gameObject);
        }

    }
}
