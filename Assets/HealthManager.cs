using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject deathExplosion;// exlosao do personagem

    Rigidbody2D pRB;

    public float BumpX, BumpY;

    public int playerHealth;  //Saúde e Dano
    public int enemyDamage;


    public static bool playerDead; // vai se ruado no outro script


    void Start()
    {
        playerDead = false;
        pRB = GetComponent<Rigidbody2D>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
      
        if(other.tag == "Enemy")
        {

            playerHealth -= enemyDamage;  // Perca de vida do jogador,danos

            if(playerHealth >= 0) {  

            GetComponent<SpriteRenderer>().color = Color.red;

            if (other.GetComponent<SpriteRenderer>().flipX == false) 
            {
                pRB.velocity = new Vector2(-BumpX, BumpY); // escquerdo

            }
            else if (other.GetComponent<SpriteRenderer>().flipX == true)
            {

                pRB.velocity = new Vector2(BumpX , BumpY);


            }

        } 
        else if (playerHealth <= 0){

                playerDead = true;

                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                // Destroy(gameObject);
                Instantiate(deathExplosion, transform.position, transform.rotation);

            }

      }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }






    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        
    }



}
