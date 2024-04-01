using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPlayerInRange = false;
    private Animator playerAnimator; // Referência ao Animator do jogador

    private InventoryManager inventoryManager;

   // public Sprite itemSprite; // A imagem do item a ser exibida na UI
   // public Image itemSlotUI; // A referência ao slot na UI onde o item será exibido


    void Start()
    {
        // Encontre o GameObject do jogador e obtenha o componente Animator
        // Supõe-se que este script esteja anexado à chave e o jogador tenha a tag "Player"
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        //inventoryManager = FindObjectOfType<InventoryManager>();

    }


    void Update()
    {
        // Verifica se o jogador está na área e se a tecla "E" foi pressionada
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PlayerPickUp();
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
        // Ativa a animação de pegar
        playerAnimator.SetTrigger("isObject");

        // Você pode querer desativar a animação depois de um curto período, dependendo de como sua animação é configurada
        Invoke("ResetPickUpAnimation", 1.0f); // Ajuste o tempo conforme necessário
        //inventoryManager.AddItemToInventory();
        // Lógica para pegar o objeto, por exemplo, destruí-lo
        Destroy(gameObject);
    }

    void ResetPickUpAnimation()
    {
        // Reseta o parâmetro de animação para voltar ao estado normal
        playerAnimator.SetBool("IsPickingUp", false);
    }
}

