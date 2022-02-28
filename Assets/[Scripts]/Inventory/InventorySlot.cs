using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Item itemInSlot = null;
    InventoryManager inventoryManager;
    PickupCategory slotPickupCategory;
    InventoryType parentInventoryType;
    Inventory currentInventory;
    MovementComponent movementComponent;
    PlayerController playerController;
    ConsoleController consoleController;

    Inventory ConsoleDefaultInventoryReference;
    Inventory ConsolePlayerInventoryReference;
    Inventory ConsoleWorldInventoryReference;
    Inventory TempPlayerInventoryReference;

    private TextMeshProUGUI slotText;
    private TextMeshProUGUI descText;
    
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        playerController = GameObject.Find("Jackie").GetComponent<PlayerController>();
        movementComponent = GameObject.Find("Jackie").GetComponent<MovementComponent>();
        currentInventory = transform.parent.GetComponent<Inventory>();
        consoleController = GameObject.Find("Console").GetComponent<ConsoleController>();
        parentInventoryType = currentInventory.inventoryType;

        ConsoleDefaultInventoryReference = inventoryManager.ConsoleDefaultInventory;
        ConsolePlayerInventoryReference = inventoryManager.ConsolePlayerInventory;
        ConsoleWorldInventoryReference = inventoryManager.ConsoleWorldInventory;
        TempPlayerInventoryReference = inventoryManager.TempPlayerInventory;

        descText = GameObject.Find("DescriptionText").GetComponent<TextMeshProUGUI>();
        slotText = transform.GetComponentInChildren<TextMeshProUGUI>();

        UpdateDescriptionText(false);
    }

    void Update()
    {
        if (slotText)
            UpdateSlotText();
    }

    public void MoveSlotItem()
    {
        if (itemInSlot == null) return;

        slotPickupCategory = itemInSlot.pickupType;
        

        switch (parentInventoryType)
        {
            case InventoryType.CONSOLE_DEFAULT:
                if (slotPickupCategory == PickupCategory.PLAYER)
                    MoveToConsolePlayer();
                if (slotPickupCategory == PickupCategory.WORLD)
                    MoveToConsoleWorld();
                break;
            case InventoryType.CONSOLE_PLAYER:
                MoveToConsoleDefault();
                break;
            case InventoryType.CONSOLE_WORLD:
                MoveToConsoleDefault();
                break;
            case InventoryType.TEMP_PLAYER:
                if (movementComponent.TempPriorityHeld)
                {
                    if (slotPickupCategory == PickupCategory.PLAYER)
                        MoveToConsolePlayer();
                    else if (slotPickupCategory == PickupCategory.WORLD)
                        MoveToConsoleWorld();
                }
                else
                    MoveToConsoleDefault();
                break;
        }

        
    }

    void MoveToConsoleDefault()
    {
        if(currentInventory == TempPlayerInventoryReference)
        {
            consoleController.IncrementPickups();
        }


        if (itemInSlot.pickupEffect == PickupEffect.MORE_SPEED)
        {
            playerController.speed = false;
        }
        if (itemInSlot.pickupEffect == PickupEffect.LOW_GRAVITY)
        {
            playerController.grav = false;
        }
        if (itemInSlot.pickupEffect == PickupEffect.MAGNETIC_PICKUPS)
        {
            playerController.mag = false;
        }
        if (itemInSlot.pickupEffect == PickupEffect.STICKY_PICKUPS)
        {
            playerController.sticky = false;
        }

        Debug.Log("Moved " + itemInSlot.itemName + " to Console Default");
        
        InventorySlot openSlot = ConsoleDefaultInventoryReference.GetNextOpenSlot();
        openSlot.itemInSlot = itemInSlot;
        itemInSlot = null;

        if (currentInventory.isFull)
            currentInventory.isFull = false;

    }

    void MoveToConsolePlayer()
    {
        if (ConsolePlayerInventoryReference.isFull) return;

        Debug.Log("Moved " + itemInSlot.itemName + " to Console Player");

        if(itemInSlot.pickupEffect == PickupEffect.MORE_SPEED)
        {
            playerController.speed = true;
        }
        if (itemInSlot.pickupEffect == PickupEffect.LOW_GRAVITY)
        {
            playerController.grav = true;
        }

        InventorySlot openSlot = ConsolePlayerInventoryReference.GetNextOpenSlot();
        openSlot.itemInSlot = itemInSlot;
        itemInSlot = null;

        if (currentInventory.isFull)
            currentInventory.isFull = false;
    }
    
    void MoveToConsoleWorld()
    {
        if (ConsoleWorldInventoryReference.isFull) return;

        Debug.Log("Moved " + itemInSlot.itemName + " to Console World");

        if (itemInSlot.pickupEffect == PickupEffect.MAGNETIC_PICKUPS)
        {
            playerController.mag = true;
        }
        if (itemInSlot.pickupEffect == PickupEffect.STICKY_PICKUPS)
        {
            playerController.sticky = true;
        }

        InventorySlot openSlot = ConsoleWorldInventoryReference.GetNextOpenSlot();
        openSlot.itemInSlot = itemInSlot;
        itemInSlot = null;

        if (currentInventory.isFull)
            currentInventory.isFull = false;

    }
    
    void MoveToTempPlayer()
    {
        if (TempPlayerInventoryReference.isFull) return;

        Debug.Log("Moved " + itemInSlot.itemName + " to Temp Player");

        InventorySlot openSlot = TempPlayerInventoryReference.GetNextOpenSlot();
        openSlot.itemInSlot = itemInSlot;
        itemInSlot = null;

        if (currentInventory.isFull)
            currentInventory.isFull = false;
    }

    void UpdateSlotText()
    {
        if (itemInSlot == null)
            slotText.text = "EMPTY";
        else
            slotText.text = itemInSlot.itemName;
    }

    public void UpdateDescriptionText(bool value)
    {
        if(!itemInSlot && descText)
        {
            descText.text = "Hover over an item to see its description!";
            return;
        }

        if (value)
            descText.text = (itemInSlot.itemName + ": " + itemInSlot.itemDesc + ".");
        else
            descText.text = "Hover over an item to see its description!";
    }


}
