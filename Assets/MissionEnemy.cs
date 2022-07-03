using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionEnemy : MonoBehaviour
{
    private Transform playerTrans;

    Rigidbody2D missileRB;

    public float missileSpeed;


     void Awake()
    {

        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        missileRB = GetComponent<Rigidbody2D>();


    }
    void Start()
    {

        if(playerTrans.localPosition.x  <  transform.localPosition.x)
        {

            missileRB.velocity = new Vector2(-missileSpeed , missileRB.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            missileRB.velocity = new Vector2(missileSpeed, missileRB.velocity.y);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
