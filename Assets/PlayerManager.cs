using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
     private Rigidbody2D  playerRB;
     private Animator playerAnim;  // movimento e acordo com a animacao

    public AudioSource shootingSound;  // efeitos sosnoros

    [SerializeField]
    private float playerSpeed;

    public  float jumpForce;//era o vertical speed


    // aqui abaixo está o pulo 
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool grounded ;


    // pulo duplo
    private bool doubleJumped;

    public Transform bulletSpawner;
    public GameObject bulletPrefab;

       
       
     
   

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

    }




    void Update()
    {

        if (grounded)
            doubleJumped = false;

        if(HealthManager.playerDead == false)
        {

            PlayerMovement();
            PlayerJump();
            playShooting();

        }
    }

    



    public  void PlayerMovement()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            playerRB.velocity = new Vector2( playerSpeed, playerRB.velocity.y);

            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerRB.velocity = new Vector2(-playerSpeed, playerRB.velocity.y);

            transform.localScale = new Vector3(-1, 1, 1);
        }

        playerAnim.SetFloat("speed", Mathf.Abs(playerRB.velocity.x));  // os dois lados fica positivo 

    }

    public void PlayerJump()
    {

        if (Input.GetButtonDown("Jump")  &&  grounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }

        if (Input.GetButtonDown("Jump") && !doubleJumped &&!grounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            doubleJumped = true ;
        }

        playerAnim.SetFloat("vSpeed", Mathf.Abs(playerRB.velocity.y));
    }

    public void playShooting()
    {


        if (Input.GetButtonDown("Fire1"))

        {
            playerAnim.SetBool("isShooting", true);
            Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            shootingSound.Play();

        } 
        else if (Input.GetButtonUp("Fire1"))
        {
            playerAnim.SetBool("isShooting", false);


        }
    }





}
