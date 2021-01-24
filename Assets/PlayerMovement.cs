using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{


    public CharacterController2D controller;
    public Transform camerapos;
    public float runSpeed = 40f;
    private float timer;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public string currItem="none";
    private int itemCount=0;
    private Animator anim;
    public string eyeTrack="";

    public TextMeshPro itemUI;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        anim.SetFloat("walk", Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
          
            anim.SetBool("jump", true);
            jump = true;
        }

       
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public bool addEye(string num)
    {
        
        eyeTrack += num;
        Debug.Log(eyeTrack);
        if (eyeTrack.Equals("12345"))
        {
            addItem("amulet");
            return true;
        }
        itemUI.text = "item: " + eyeTrack;
        return false;
    }
    public void transport()
    {
        transform.position = new Vector3(-47f, 4f, 1f);
        camerapos.position = new Vector3(-47.55f, 0.25f, -1f);
    }
    public void addItem(string item)
    {

            switch (item)
            {
                case ("cactus"):
                    
                    currItem = "cactus";
       
                    Debug.Log("Sprite changed");
                         itemUI.text = "item: antidoto de cactus";
                    break;
                case ("pzhm"):
                    currItem = "pzhm";
                    itemUI.text = "item: zanahoria PZHM";
                    break;
                case ("amulet"):
                    currItem = "amulet";
                    itemUI.text = "item: amuleto";
                    break;
        }
        
    }


    public void winGame(string win)
    {
        switch (win)
        {
            case ("desert"):
                transform.position = new Vector2(-25,15);
                camerapos.position= new Vector3(-23.55f, 14.25f,-1f);
                break;
            case ("forest"):
                transform.position = new Vector2(-45, 15);
                camerapos.position = new Vector3(-47.55f, 14.25f, -1f);
     
                break;
            case ("winter"):
                transform.position = new Vector2(-71, 15);
                camerapos.position = new Vector3(-71.55f, 14.25f, -1f);
                break;
          
        }
            itemUI.text = "";
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
           anim.SetBool("jump", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

     
        if (collision.transform.CompareTag("water"))
        {
         
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            GetComponent<Rigidbody2D>().gravityScale = .1f;
            controller.m_JumpForce = 0f;
            camerapos.GetComponent<Camera>().backgroundColor = new Color(0f, 0f, .5f, 1f);
        }
      
        else
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

                timer = Time.time + .15f;
            }
        }
    }
}