using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cactus : MonoBehaviour
{

    public Sprite emptys;
    public bool empty = false;
    [SerializeField]
    private TextMeshPro hint;
    public void changeSkin()
    {
        empty = true;
        GetComponent<SpriteRenderer>().sprite = emptys;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 
            if (Input.GetKeyDown(KeyCode.E) && !empty)
            {
                collision.transform.GetComponent<PlayerMovement>().addItem("cactus");
                changeSkin();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            hint.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            hint.gameObject.SetActive(false);
        }
    }
}
