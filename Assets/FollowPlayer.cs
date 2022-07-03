using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{


   Transform playerTrans;
     

    public float camXOffset;
    public float camYOffeset;

    public  float camSpeed;


    public Vector3 min;
    public Vector3 max;
   


    void start()
    {

        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;  //nome do playerTrans

    }


    void Update()
    {
        CamMoviment();
        CameraMargins();

    }

    void CamMoviment()  ///
    {

       Vector3 newPos = new Vector3(playerTrans.position.x - camXOffset, playerTrans.position.y + camYOffeset, transform.position.z);
       transform.position = Vector3.Lerp( transform.position, newPos , camSpeed * Time.deltaTime);
         
    }


    void CameraMargins()
    {

        if(transform.position.x <= min.x)
        {
            // posicao x menor
         transform.position = new Vector3(min.x, transform.position.y, transform.position.z);
        }

        if(transform.position.x >= max.x)
        {  // posicao x maior 
            transform.position = new Vector3(max.x, transform.position.y, transform.position.z);
        }

        // poscao y menor 
        if(transform.position.y <= max.y)
        {
            transform.position = new Vector3(transform.position.x, min.y , transform.position.z);
        }

        // posicao y maior 
        if (transform.position.y >= max.y)
        {
            transform.position = new Vector3(transform.position.x, max.y, transform.position.z);
        }

    }

       
}
