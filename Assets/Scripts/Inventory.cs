using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    private GameObject[] slotsAux;
    void Start()
    {
        slotsAux = new GameObject[4];
        for (int i = 0; i < isFull.Length; i++)
        {
            isFull[i] = false;
            slotsAux[i] = slots[i];
            //slots[i] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(GameObject item, string itemName)
    {
        // Encontre o primeiro slot vazio no inventário
        for (int i = 0; i < isFull.Length; i++)
        {
            if (isFull[i] == false)
            {
                isFull[i] = true; // Marque o slot como cheio
                slots[i] = Instantiate(item, slots[i].transform, false); // Crie o ícone do item no slot
                slots[i].name = itemName; // Atualize o nome do slot para refletir o item

                Debug.Log($"Slot ({i + 1}) {itemName}"); // Log com o nome atualizado
                break;
            }
        }
    }


    public void RemoveItem(string itemName)
    {
        Debug.Log("A remover -> " + itemName);
        int indexToRemove = -1;
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log(slots[i].name + " " +itemName);
            if (slots[i] != null && slots[i].name == itemName && isFull[i] == true)
            {
                isFull[i] = false;
                Destroy(slots[i]);  // Destruir o ícone visual do item
                slots[i] = slotsAux[i];
                indexToRemove = i;
                break;
            }
        }
        if (indexToRemove != -1)
        {
            UpdateUI(indexToRemove);
        }
    }

    public void UpdateUI(int startIndex)
    {
        // Deslocar todos os itens para a esquerda a partir do índice startIndex
        for (int i = startIndex; i < slots.Length - 1; i++)
        {
            if (isFull[i + 1] == false)
            {
                break; // Se o próximo slot não estiver cheio, pare o loop
            }
            else
            {
                slots[i] = slots[i + 1]; // Mover o ícone para a esquerda
                isFull[i] = isFull[i + 1];
                slots[i + 1] = slotsAux[i + 1];
                isFull[i + 1] = false;
            }

            /*if (slots[i] != null)
            {
                slots[i].transform.position = slots[i].transform.parent.GetChild(i).position;
            }*/
        }
    }

}
