using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;

    public float enemySpeed;

    public bool goRight;


    public ShootingEnemy range;  // do outro script

     void Awake()
    {


        range = GetComponentInChildren<ShootingEnemy>();

    }


    void Start()
    {

        if (!goRight)
        {

            transform.position = startPoint.transform.position;
        }
        else
        {
            transform.position = endPoint.transform.position;
        }

    }

     
    void Update()
    {
        if (range.playerInRange == false)
        {
            transform.localScale = new Vector3(1, 1, 1); // invertido

            if (goRight == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, enemySpeed * Time.deltaTime);
                if (transform.position == endPoint.transform.position)
                {

                    transform.localScale = new Vector3(-1, 1, 1);
                    goRight = false;

                }
            }

        }


        if (!goRight == true)
        {
            transform.localScale = new Vector3(-1, 1, 1); // invertido

            transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, enemySpeed * Time.deltaTime);
            if (transform.position == startPoint.transform.position)
            {

                transform.localScale = new Vector3(1, 1, 1);
                goRight = true;

            }
        }

    }



    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(startPoint.transform.position, endPoint.transform.position);

    }
}
