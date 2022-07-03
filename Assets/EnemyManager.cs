using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private Animator eAnim;// destry
    public float animDelay;// quanto tempo pra destoiro objeto 

    public GameObject healthBar;  //primeira  vatiavel - barra de saúde 


    public int enemyHealth;

    //private float currentHealth
    private float curHealth;  // segunda variavel do HealthBar "é private " recebe valor de 100 current

    public int enemyValue;

    public static bool enemyDead = false;// utimo script


     void Start()
    {
        curHealth = enemyHealth;

        eAnim = GetComponent<Animator>();

    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if(col.tag == "Bullet")
        {

            curHealth -= BulletMoviment.damage;  //
            
           
            float barLength = curHealth / enemyHealth;  // o que é isso ?resposta : criu uma variavel chmda barlength
            SetHealthBar(barLength);// o que é isso ?

            if (curHealth <= 0)
            {
                enemyDead = true;
                eAnim.SetBool("isDead", true);//
                Debug.Log(enemyValue);
                Destroy(gameObject ,animDelay);
            }

            
        }
        
    }


    public void SetHealthBar (float eHealth)
    {

        healthBar.transform.localScale = new Vector3(eHealth , healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }  


}
