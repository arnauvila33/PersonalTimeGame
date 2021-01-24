using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{


    public Transform camerapos;
    public float moveSpeed;
    public float jumpHeight;

    private Animator anim;
    private float timer;
    private bool isGrounded=true;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
           anim.SetBool("jump", true);
            velocity.y = jumpHeight; //"jump" at 20 meters per second

            

            isGrounded = false;
        }
        else
        {
            
            anim.SetFloat("walk", Input.GetAxis("Horizontal"));
        }
        velocity.x = Input.GetAxis("Horizontal") * moveSpeed;

        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timer < Time.time)
        {
            Vector2 temp = camerapos.position;
            switch (collision.name)
            {
                case ("rightRoom"):
                    temp.x += 24f;
                    camerapos.position = temp;
                    break;
                case ("leftRoom"):
                    temp.x -= 24f;
                    camerapos.position = temp;
                    break;
                case ("topRoom"):
                    temp.y += 14f;
                    camerapos.position = temp;
                    break;
                case ("bottomRoom"):
                    temp.y -= 14f;
                    camerapos.position = temp;
                    break;
            }
            timer = Time.time+.25f;
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("ground"))
        {
            isGrounded = true;
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            
            anim.SetBool("jump", false);
        }
    }
}
