using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{
    CONSOLE_DEFAULT,
    CONSOLE_PLAYER,
    CONSOLE_WORLD,
    TEMP_PLAYER
}

public class Inventory : MonoBehaviour
{
    public InventoryType inventoryType;
    public bool isFull;

    [SerializeField] GameObject inventoryPanel;
    [SerializeField] List<InventorySlot> itemSlots = new List<InventorySlot>();
    
    int inventorySpaces;
    
    void Start()
    {
        inventorySpaces = inventoryPanel.transform.childCount;
        for (int i = 0; i < inventorySpaces; i++)
        {

            itemSlots[i] = inventoryPanel.transform.GetChild(i).GetComponent<InventorySlot>();
        }

    }

    public InventorySlot GetNextOpenSlot()
    {
        for (int i = 0; i < inventorySpaces; i++)
        {
            if (itemSlots[i].itemInSlot == null)
            {
                Debug.Log("Open Slot at slot " + i);
                if(i == inventorySpaces - 1)
                {
                    isFull = true;
                }
                return itemSlots[i];
            }
        }
        Debug.Log("SHOULD NEVER GET HERE!!!!!");
        return itemSlots[0];
    }
}
