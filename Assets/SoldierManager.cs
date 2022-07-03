using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoldierManager : MonoBehaviour
{
    public Image health;

    public GameObject explosionPrefab; //  instaciou 
    public AudioSource deathSFX;

    public float maxHealth;
    float curHealth;  // current

    public int enemyValue;

// pontucao que vai ganhar
   
    void Start()
    {

        curHealth = maxHealth;
        health.fillAmount = curHealth / maxHealth;

        
    }


     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {


            curHealth -= BulletMoviment.damage;
            health.fillAmount = curHealth / maxHealth;

            if(curHealth <= 0)
            {

                Instantiate(explosionPrefab, transform.position, transform.rotation);
                deathSFX.Play();
                Debug.Log(enemyValue);
                Destroy(gameObject);
            }


        }

    }

     
}
