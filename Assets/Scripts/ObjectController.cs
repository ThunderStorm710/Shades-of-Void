using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private Animator playerAnimator; 

    private GameObject player;
    public GameObject itemButton;

    private Inventory inventory;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null){
            playerAnimator = player.GetComponent<Animator>();
            inventory = player.GetComponent<Inventory>();
        }


    }


    void Update()
    {

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {

            PlayerController playerController = player.GetComponent<PlayerController>();

            if (playerController.hasPickaxe && gameObject.tag == "Wall")
            {
                Debug.Log("Parede a desaparecer.");
                gameObject.SetActive(false);
                player.GetComponent<PlayerController>().hasPickaxe = false;
                inventory.RemoveItem("Pickaxe");


            }
            else if (playerController.hasAxe && gameObject.tag == "Wood Wall") {
                Debug.Log("Parede de madeira a desaparecer.");
                gameObject.SetActive(false);
                player.GetComponent<PlayerController>().hasAxe = false;
                inventory.RemoveItem("Axe");


            }
            else if (gameObject.tag == "Wall") {
                Debug.Log("Falta a picareta.");

            } else if (gameObject.tag == "Wood Wall") {
                Debug.Log("Falta a machado.");
            }

            if (gameObject.tag != "Wall" && gameObject.tag != "Wood Wall") { 

                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.AddItem(itemButton, gameObject.name);
                        player.GetComponent<PlayerController>().ObtainObject(gameObject);

                        Destroy(gameObject);
                        break;
                    }
                }
                PlayerPickUp();
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
    

    void PlayerPickUp()
    {
        playerAnimator.SetTrigger("isObject");

        Invoke("ResetPickUpAnimation", 1.0f);
        Destroy(gameObject);
    }

    void ResetPickUpAnimation()
    {
        playerAnimator.SetBool("IsPickingUp", false);
    }
}

