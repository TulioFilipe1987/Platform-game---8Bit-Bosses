using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatrol : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;

    public float enemySpeed;

    public   bool isGoingRight;

    void Start()
    {

        if(!isGoingRight)
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
        if(EnemyManager.enemyDead == false)  // ultimo colocado
        {
            if (!isGoingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, enemySpeed * Time.deltaTime); // poto final
                if (transform.position == endPoint.transform.position)
                {
                    isGoingRight = true;

                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }

            if (isGoingRight)
            {

                transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, enemySpeed * Time.deltaTime); // ponto imcial
                if (transform.position == startPoint.transform.position)
                {
                    isGoingRight = false;  // quando chegar la fica "FALSO"

                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }


       
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(startPoint.transform.position, endPoint.transform.position);

    }


}
