using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPlayerInRange = false;
    private Animator playerAnimator; 
    private GameObject player;
    private Inventory inventory;
    public GameObject itemButton;



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
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    player.GetComponent<PlayerController>().ObtainObject(gameObject);
                    player.GetComponent<PlayerController>().ObtainPickaxe(gameObject);

                    Destroy(gameObject);
                    break;
                }
            }
            PlayerPickUp();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;

            if (collision.GetComponent<PlayerController>().hasPickaxe){
                Debug.Log("Parede desaparecendo.");
                gameObject.SetActive(false); // Faz a parede desaparecer
            } else {
                Debug.Log("Falta a picareta.");
   
            }

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

