using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class npc : MonoBehaviour
{
    [SerializeField]
    private List<string> dialogueList;

    [SerializeField]
    private bool hasAction;
    [SerializeField]
    private string item;

    public TextMeshPro dialogue;
    public TextMeshPro action;
    public TextMeshPro conversation;

    private bool talking=false;

    private int counter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (hasAction)
                action.gameObject.SetActive(true);
            dialogue.gameObject.SetActive(true);
            talking = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (hasAction)
                action.gameObject.SetActive(false);
            dialogue.gameObject.SetActive(false);
            conversation.gameObject.SetActive(false);
            talking = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E) && hasAction)
            {
                if (hasAction)
                    action.gameObject.SetActive(false);
                dialogue.gameObject.SetActive(false);

                if (gameObject.tag.Equals("duende"))
                {
                    collision.GetComponent<PlayerMovement>().transport();
                }
                else if (gameObject.tag.Equals("pzhm"))
                {
                    collision.GetComponent<PlayerMovement>().addItem("pzhm");
                    GameObject.Destroy(gameObject);
                }
                else if(gameObject.tag.Equals("eye"))
                {
                    bool c=collision.GetComponent<PlayerMovement>().addEye(gameObject.name);
                    if (c)
                    {
                        conversation.gameObject.SetActive(true);
                        conversation.text = "El amuleto es tuyo...";
                    }
                }
                else if (item.Equals(collision.GetComponent<PlayerMovement>().currItem))
                {
                    Debug.Log("Give cactus");
                    switch (item)
                    {
                        case ("cactus"):
                            collision.GetComponent<PlayerMovement>().winGame("desert");
                            break;
                        case ("pzhm"):
                            collision.GetComponent<PlayerMovement>().winGame("forest");
                            break;
                        case ("amulet"):
                            collision.GetComponent<PlayerMovement>().winGame("winter");
                            break;

                        
                    }
                    GameHandler.win = true;
                }
            }
        }
    }

    private void Update()
    {
        if (talking)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (hasAction)
                    action.gameObject.SetActive(false);
                dialogue.gameObject.SetActive(false);
                conversation.gameObject.SetActive(true);
                conversation.text = dialogueList[counter];
                counter++;
                if (counter == dialogueList.Count)
                {
                    counter = 0;
                }
            }


        }
    }
}
