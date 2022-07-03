using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

    public GameObject player; //psicao do player

    public GameObject misselePrefab;// missel1
    public GameObject misseleSpawner;//misse 2

    public Transform enemyTrans;// posica do inimigo

    public Animator enemyAnim;

    public AudioClip misseleSFX;

     

    public bool playerInRange;


    public float shootingRate;//avaliar missel
    float shootingCount;//contagem do missel

    void Start()
    {

        enemyAnim = GetComponentInParent<Animator>();
         
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerInRange)
        {

            if(player.transform.position.x  <=  enemyTrans.transform.position.x)
            {
                enemyTrans.transform.localScale = new Vector3 (1, 1, 1);

            }
            else if(player.transform.position.x >= enemyTrans.transform.position.x)
            {

                enemyTrans.transform.localScale = new Vector3(-1, 1, 1);

            }

            shootingCount += Time.deltaTime;  // aumenta a a variavel  cada segundo


            if(shootingCount >= shootingRate)
            {

               Instantiate(misselePrefab, misseleSpawner.transform.position, misselePrefab.transform.rotation);
               shootingCount = 0;

                GetComponent<AudioSource>().PlayOneShot(misseleSFX);
                

            }
        }

        
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            enemyAnim.SetBool("playerInRange" , true);

            playerInRange = true;

        }

    }

     void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            enemyAnim.SetBool("playerInRange", false);

            playerInRange = false;

            shootingCount = 0; //na saida

        }


    }
}
