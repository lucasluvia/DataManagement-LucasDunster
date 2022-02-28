using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item itemType;

    InventoryManager inventoryManager;
    PlayerController playerController;
    Renderer renderer;
    Collider collider;

    public bool inMagRange;

    void Start()
    {
        playerController = GameObject.Find("Jackie").GetComponent<PlayerController>();
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (!playerController.Paused)
            transform.Rotate(new Vector3(0, 60 * Time.deltaTime, 0), Space.World);

        if (inMagRange && playerController.mag)
        {
            Vector3 temp = new Vector3(playerController.gameObject.transform.position.x, playerController.gameObject.transform.position.y + 1.5f, playerController.gameObject.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, temp, 2 * Time.deltaTime);
        }

    }

    public void RemovePickupFromWorld()
    {
        InventorySlot openSlot = inventoryManager.TempPlayerInventory.GetNextOpenSlot();
        openSlot.itemInSlot = itemType;

        renderer.enabled = false;
        collider.enabled = false;
        itemType.CollectItem();
    }



}
